using CryptoCurrency.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CryptoCurrency.ViewModel
{
    class TopCoinsVM
    {
        public ObservableCollection<TopCryptocurrenciesItem> CryptoItems { get; set; }

        public TopCoinsVM()
        {
            CryptoItems = new ObservableCollection<TopCryptocurrenciesItem>();
            GetTopCoins();
        }

        private BitmapSource GenerateImage(string uri)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(uri);
            bitmap.EndInit();

            return bitmap;
        }
        private async Task GetTopCoins()
        {
            CoinGeckoAPI coins = new CoinGeckoAPI();
            
            var topCoins = await coins.GetTopCoins();
            if(topCoins  != null) {
                foreach (var item in topCoins)
                {
                    TopCryptocurrenciesItem itemViewModel = new TopCryptocurrenciesItem();

                    itemViewModel.CryptName.Content = FormatName(item.Name);
                    itemViewModel.CryptCost.Content =  FormatPrice(item.CurrentPrice);
                    itemViewModel.Crypt24h = FormatPricePersent(itemViewModel.Crypt24h, item.Price_change_percentage_24h);
                    itemViewModel.coins = item;
                    itemViewModel.CryptImage.Source = GenerateImage(item.Image);

                    CryptoItems.Add(itemViewModel);
                }

                var Navigation = Application.Current.MainWindow.DataContext as Navigation;
                Navigation.OutputCoinInfo.Execute(topCoins[0]);
                Navigation.coins = topCoins[0];
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.SetRadioButtonBasedOnCurrentVM(typeof(CoinsVM));

            }
        }

        private System.Windows.Controls.Label FormatPricePersent(System.Windows.Controls.Label label, double persent)
        {
            if (persent > 0)
            {
                label.Content = "▲ " + Math.Round(persent, 2) + "%";
                label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#31d014"));
            }
            else
            {
                label.Content = "▼ " + Math.Round(persent, 1) + "%";
                label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fc2009"));
            }
            return label;
        }

        private string FormatName(string CryptName)
        {
            string[] words = CryptName.Split(' ');

            if (words.Length >= 2)
            {
                string result = string.Join(" ", words.Take(2));
                return result;
            }
            else 
                return CryptName;
        }

        private string FormatPrice(double price)
        {
            if (price >= 1000)
            {
                double formattedValue = price / 1000.0;
                return "$" + formattedValue.ToString("0.0") + "k";
            }
            else
            {
                return "$" + price.ToString("0.0");
            }
        }

    }
}
