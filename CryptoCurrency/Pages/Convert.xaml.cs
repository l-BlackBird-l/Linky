using CryptoCurrency.Model;
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
    /// Interaction logic for Convert.xaml
    /// </summary>
    public partial class Convert : UserControl
    {
        public Convert()
        {
            InitializeComponent();
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            if(FromCoinComboBox.SelectedIndex != -1 && ToCoinComboBox.SelectedIndex != -1 && !string.IsNullOrEmpty(Count.Text))
            {
                double count;
                if (double.TryParse(Count.Text.Replace(',', '.'), out count))
                {
                    var from = (ConvertItem)FromCoinComboBox.SelectedItem;
                    var to = (ConvertItem)ToCoinComboBox.SelectedItem;
                    var result = ((from.price * count) / to.price);
                    Result.Text = Math.Round(result, 10).ToString();
                }
                else
                    Result.Text = string.Empty;
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var tempItem = FromCoinComboBox.SelectedIndex;
            FromCoinComboBox.SelectedIndex = ToCoinComboBox.SelectedIndex;
            ToCoinComboBox.SelectedIndex = tempItem;
        }

        private void Validate_Input(object sender, TextCompositionEventArgs e)
        {
            if (!IsInputValid(e.Text))
            {
                e.Handled = true;
            }
        }

        private bool IsInputValid(string input)
        {
            string allowedCharacters = "0123456789.,";
            foreach (char c in input)
                if (!allowedCharacters.Contains(c))
                    return false;

            return true;
        }
    }
}
