using CryptoCurrency.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CryptoCurrency.ViewModel
{
    class FavoriteVM
    {
        public ObservableCollection<FavoriteItem> CryptoItems { get; set; }

        public FavoriteVM() {
            CryptoItems = new ObservableCollection<FavoriteItem>();
            GetFovorites(GenerateFavoritesString(Settings.Default.Favorites));
        }

        private BitmapSource GenerateImage(string uri)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(uri);
            bitmap.EndInit();

            return bitmap;
        }

        private async Task GetFovorites(string Favorites)
        {
            CoinGeckoAPI coins = new CoinGeckoAPI();

            var topCoins = await coins.GetFavoritesCoins(Favorites);
            if (topCoins != null)
            {
                foreach (var item in topCoins)
                {
                    FavoriteItem itemViewModel = new FavoriteItem();

                    itemViewModel.CryptName.Content = FormatName(item.Name);
                    itemViewModel.CryptCost.Content = FormatPrice(item.CurrentPrice);
                    itemViewModel.Crypt24h = FormatPricePersent(itemViewModel.Crypt24h, item.Price_change_percentage_24h);
                    itemViewModel.CryptImage.Source = GenerateImage(item.Image);
                    itemViewModel.coins = item ;
                    CryptoItems.Add(itemViewModel);
                }
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

        private string GenerateFavoritesString(string Favorites) {
            string trimmedString = Favorites.Trim(',', ' ', '.');
            string[] tokens = trimmedString.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string encodedString = string.Join("%2C%20", Array.ConvertAll(tokens, HttpUtility.UrlEncode));
            return Favorites;
        }
    }
}
