using CryptoCurrency.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoCurrency.Pages
{
    /// <summary>
    /// Interaction logic for TopCryptocurrenciesItem.xaml
    /// </summary>

    public partial class TopCryptocurrenciesItem : UserControl
    {
        public Coins coins = new Coins();
        public TopCryptocurrenciesItem()
        {
            InitializeComponent();
        }

        private void CoinItemDown(object sender, MouseButtonEventArgs e)
        {
            var Navigation = Application.Current.MainWindow.DataContext as Navigation;
            Navigation.OutputCoinInfo.Execute(coins);
            Navigation.coins = coins;
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.SetRadioButtonBasedOnCurrentVM(typeof(CoinsVM));
        }
    }
}
