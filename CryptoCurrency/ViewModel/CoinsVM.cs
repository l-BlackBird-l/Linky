using CryptoCurrency.Model;
using CryptoCurrency.Utilities;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CryptoCurrency.ViewModel
{
    public class CoinsVM
    {

        public SeriesCollection Series { get; set; }
        public string[] LabelsX { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public ICommand GoToWebSite { get; private set; }

        private Coins _CoinInfo;
        public Coins CoinInfo
        {
            get { return _CoinInfo; }
            set { _CoinInfo = value; }
        }
        public string CurrentPriceInDollars => $"Price: {FormatPrice(CoinInfo.CurrentPrice)}";
        public string HighLow24h => $"24h High/Low: {FormatPrice(CoinInfo.High_24h)}/{FormatPrice(CoinInfo.Low_24h)}";
        public string AllTimeHigh => $"{CoinInfo.Ath}$";
        public string AllTimeLow => $"{CoinInfo.Atl}$";
        public string AllTimeHighPersent => $"{FormatPricePersent(CoinInfo.Ath_change_percentage, 'h')}";
        public string AllTimeLowPersent => $"{FormatPricePersent(CoinInfo.Atl_change_percentage, 'l')}";
        public string AllTimeLowData => $"{FormatDate(CoinInfo.Atl_date)}";
        public string AllTimeHighData => $"{FormatDate(CoinInfo.Ath_date)}";

        private SolidColorBrush _lowPersentColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#31d014"));
        private SolidColorBrush _highPersentColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#31d014"));


        public void GenerateChart()
        {
            if (CoinInfo.id != null)
            {
                CoinCapAPI coinCap = new CoinCapAPI();
                List<CoinHistory> coins = coinCap.GetCoinHistories(CoinInfo.id);

                List<double> GetOnlyPrice = new List<double>();
                List<string> GetOnlyDate = new List<string>();

                foreach (CoinHistory coin in coins)
                {
                    GetOnlyPrice.Add(double.Parse(coin.priceUsd));
                    GetOnlyDate.Add(FormatDateForChart(coin.time));
                }
                Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = CoinInfo.Name,
                    Values = new ChartValues<double>(GetOnlyPrice),
                    Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#537afc"))
        }
            };
                LabelsX = GetOnlyDate.ToArray();
                YFormatter = value => FormatPriceForChart(value);
            }
        }


        public SolidColorBrush LowPersentColor
        {
            get { return _lowPersentColor; }
            set { _lowPersentColor = value; }
        }

        public SolidColorBrush HighPersentColor
        {
            get { return _highPersentColor; }
            set { _highPersentColor = value; }
        }

        public CoinsVM()   { }
        public CoinsVM(Coins coinTask) {
            _CoinInfo = new Coins();
            GetCoinsData(coinTask);
            GenerateChart();
            GoToWebSite = new RelayCommand(GoToLink);
        }


        private string FormatPricePersent(double persent, char LowOrHigh)
        {
            string CoinPersent;
            if (persent > 0)
            {
                CoinPersent = "▲ " + Math.Round(persent, 2) + "%";
                if (LowOrHigh == 'l')
                    LowPersentColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#31d014"));
                else
                    HighPersentColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#31d014"));

            }
            else
            {
                CoinPersent = "▼ " + Math.Round(persent, 1) + "%";
                if (LowOrHigh == 'l')
                    LowPersentColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fc2009"));
                else
                    HighPersentColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fc2009"));
            }
            return CoinPersent;
        }

        private string FormatDate(DateTimeOffset? date)
        {
            if (date == null)
                return "";
            string formattedDate = date.Value.Date.ToString("dd/MM/yyyy");
            return formattedDate;
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
        private void GoToLink(object parameter)
        {
            Process.Start(new ProcessStartInfo($"https://coinmarketcap.com/currencies/{CoinInfo.id}/") { UseShellExecute = true });
        }

        private string FormatDateForChart(long Date)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(Date);
            return dateTimeOffset.ToString("dd.MM");
        }
        private string FormatPriceForChart(double price)
        {
            return $"{price.ToString("#,0.##")}";
        }

        private void GetCoinsData(Coins Coin)
        {
            var coinData = new Coins
            {
                id = Coin.id,
                Image = Coin.Image,
                Name = Coin.Name,
                Official_forum_url = Coin.Official_forum_url,
                CurrentPrice = Coin.CurrentPrice,
                Price_change_percentage_24h = Coin.Price_change_percentage_24h,
                High_24h = Coin.High_24h,
                Low_24h = Coin.Low_24h,
                Ath = Coin.Ath,
                Ath_change_percentage = Coin.Ath_change_percentage,
                Ath_date = Coin.Ath_date,
                Atl = Coin.Atl,
                Atl_change_percentage = Coin.Atl_change_percentage,
                Atl_date = Coin.Atl_date,
                Market_cap_rank = Coin.Market_cap_rank,
            };
            CoinInfo = coinData;
        }
    }
       
}
