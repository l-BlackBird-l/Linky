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

namespace CryptoCurrency
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove(); 
        }

        private void AppExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AppMinimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        public void SetRadioButtonBasedOnCurrentVM(Type currentViewModelType)
        {
            if (currentViewModelType == typeof(CoinsVM))
            {
                CoinButton.IsChecked = true;
            }
            else if (currentViewModelType == typeof(SearchVM))
            {
                SearchButton.IsChecked = true;
            }
            else if (currentViewModelType == typeof(ConvertVM))
            {
                ConvertButton.IsChecked = true;
            }
            else if (currentViewModelType == typeof(FavoriteVM))
            {
                CoinButton.IsChecked = true;
            }
        }
    }
}
