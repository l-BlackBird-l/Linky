using CryptoCurrency.Pages;
using CryptoCurrency.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoCurrency.ViewModel
{
    class Navigation : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand CoinsCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand ConvertCommand { get; set; }
        public ICommand FavoritesCommand { get; set; }
        private void Coins(object obj) => CurrentView = new CoinsVM();
        
        private void Favorite(object obj) => CurrentView = new FavoriteVM();
        private void Convert(object obj) => CurrentView = new ConvertVM();
        private void Search(object obj) => CurrentView = new SearchVM();
        

        public Navigation()
        {
            CoinsCommand = new RelayCommand(Coins);
            FavoritesCommand = new RelayCommand(Favorite);
            SearchCommand = new RelayCommand(Search);
            ConvertCommand = new RelayCommand(Convert);
  
            // Startup Page
            CurrentView = new CoinsVM();
        }
    }
}
