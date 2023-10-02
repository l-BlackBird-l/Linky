using CryptoCurrency.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CryptoCurrency.ViewModel
{
    public class ConvertVM
    {
        public ObservableCollection<ConvertItem> ConvertCoins { get; set; }

        public ConvertVM()
        {
            ConvertCoins = new ObservableCollection<ConvertItem>();
            GetConvertCoins();
        }

        private BitmapSource GenerateImage(string uri)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(uri);
            bitmap.EndInit();

            return bitmap;
        }
        private async Task GetConvertCoins()
        {
            CoinGeckoAPI Api = new CoinGeckoAPI();

            var data = await Api.GetCoinsForExchange();

            if (data != null)
            {
                ConvertItem USD = new ConvertItem();
                USD.CoinName.Content = "USD";
                USD.Image.Source = GenerateImage("https://s2.coinmarketcap.com/static/img/coins/64x64/20317.png");
                USD.price = 1;

                ConvertCoins.Add(USD);

                foreach (var items in data)
                {
                    ConvertItem item = new ConvertItem();
                    item.CoinName.Content = items.Name;
                    item.Image.Source = GenerateImage(items.Image);
                    item.price = items.CurrentPrice;

                    ConvertCoins.Add(item);
                }
            }
        }

    }
}
