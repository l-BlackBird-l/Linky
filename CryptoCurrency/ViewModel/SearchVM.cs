using CryptoCurrency.Pages;
using CryptoCurrency.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CryptoCurrency.ViewModel
{
    class SearchVM
    {
        public ICommand SearchCommand { get; set; }
        public string CryptID { get; set; }
        private List<Coins> Coin { get; set; }
        public SearchVM()
        {
            SearchCommand = new RelayCommand(SearchCryptocurrencyButtom);
        }

        private void SearchCryptocurrencyButtom(object parameter)
        {
            SearchCryptocurrency();
        }
        private async Task SearchCryptocurrency()
        {
            CoinGeckoAPI Api = new CoinGeckoAPI();
            Coin = await Api.GetSearchingCoins(CryptID);

            var Navigation = Application.Current.MainWindow.DataContext as Navigation;
            Navigation.OutputCoinInfo.Execute(Coin.FirstOrDefault());
            Navigation.coins = Coin.FirstOrDefault();
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.SetRadioButtonBasedOnCurrentVM(typeof(CoinsVM));
        }

    }
}