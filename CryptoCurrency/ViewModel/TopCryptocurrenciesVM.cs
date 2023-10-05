using CryptoCurrency.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CryptoCurrency.ViewModel
{

    public class TopCryptocurrenciesVM : INotifyPropertyChanged
    {
        private string _cryptName;
        public string CryptName
        {
            get { return _cryptName; }
            set
            {
                _cryptName = value;
                OnPropertyChanged("CryptName");
            }
        }

        private string _cryptCost;
        public string CryptCost
        {
            get { return _cryptCost; }
            set
            {
                _cryptCost = value;
                OnPropertyChanged("CryptCost");
            }
        }

        private string _crypt24h;
        public string Crypt24h
        {
            get { return _crypt24h; }
            set
            {
                _crypt24h = value;
                OnPropertyChanged("Crypt24h");
            }
        }

        private Coins _coins;
        public Coins Coins
        {
            get { return _coins; }
            set
            {
                _coins = value;
                OnPropertyChanged("Coins");
            }
        }


        private Brush _LabelColor;
        public Brush LabelColor
        {
            get { return _LabelColor; }
            set
            {
                _LabelColor = value;
                OnPropertyChanged("LabelColor");
            }
        }

        private ImageSource _cryptImage;
        public ImageSource CryptImage
        {
            get { return _cryptImage; }
            set
            {
                _cryptImage = value;
                OnPropertyChanged("CryptImage");
            }
        }

        public ICommand CoinItemDownCommand { get; private set; }

        public TopCryptocurrenciesVM()
        {
            Coins = new Coins();
            CoinItemDownCommand = new RelayCommand(obj => CoinItemDown());
        }

        private void CoinItemDown()
        {
            var Navigation = Application.Current.MainWindow.DataContext as Navigation;
            Navigation.OutputCoinInfo.Execute(Coins);
            Navigation.coins = Coins;
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.SetRadioButtonBasedOnCurrentVM(typeof(CoinsVM));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
