using CryptoCurrency.Pages;
using CryptoCurrency.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoCurrency.ViewModel
{
    class Navigation : ViewModelBase
    {

        public Coins coins  = new Coins();

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public RelayCommand CoinsCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand ConvertCommand { get; set; }
        public RelayCommand FavoritesCommand { get; set; }
        public RelayCommand<Coins> OutputCoinInfo { get; set; }

        private void Coins(object obj) => CurrentView = new CoinsVM(coins);

        private void Favorite(object obj) => CurrentView = new FavoriteVM();

        private void Convert(object obj) => CurrentView = new ConvertVM();

        private void Search(object obj) => CurrentView = new SearchVM();


        public Navigation()
        {
            CoinsCommand = new RelayCommand(Coins);
            FavoritesCommand = new RelayCommand(Favorite);
            SearchCommand = new RelayCommand(Search);
            ConvertCommand = new RelayCommand(Convert);
            OutputCoinInfo = new RelayCommand<Coins>(coin => SetCoin(coin));

            // Startup Page
            CurrentView = new CoinsVM(coins);
        }

        public void SetCoin(Coins coin)
        {
            CoinsVM coinVM = new CoinsVM(coin);
            CurrentView = coinVM;
        }
    }
}
