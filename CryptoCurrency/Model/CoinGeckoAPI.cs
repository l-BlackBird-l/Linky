using CryptoCurrency.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace CryptoCurrency
{
    class CoinGeckoAPI
    {
        private const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36";
        private const string XRequestedWith = "XMLHttpRequest";
        private static readonly HttpClient client = new HttpClient();

        public CoinGeckoAPI()
        {
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            client.DefaultRequestHeaders.Add("X-Requested-With", XRequestedWith);
        }

        public async Task<List<Coins>> GetTopCoins()
        {
            return await LoadCoins("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1&sparkline=false&locale=en");
        }

        public async Task<List<Coins>> GetSearchingCoins(string CoinID)
        {
            return await LoadCoins($"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&ids={CoinID}&order=market_cap_desc&per_page=2&page=1&sparkline=false&locale=en");
        }

        public async Task<List<ConvertCoin>> GetCoinsForExchange()
        {
            return await LoadConvertCoins("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=200&page=1&sparkline=false&locale=en");
        }

        public async Task<List<Coins>> GetFavoritesCoins(string FavoritesList)
        {
            return await LoadCoins($"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&ids={FavoritesList}&order=market_cap_desc&per_page=100&page=1&sparkline=false&locale=en");
        }

        private async Task<List<Coins>> LoadCoins(string apiUrl)
        {
            return await ExecuteRequest<List<Coins>>(apiUrl);
        }

        private async Task<List<ConvertCoin>> LoadConvertCoins(string apiUrl)
        {
            return await ExecuteRequest<List<ConvertCoin>>(apiUrl);
        }

        private async Task<T> ExecuteRequest<T>(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(content);
                }
                else
                {
                    MessageBox.Show(response.StatusCode.ToString());
                    return default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return default;
            }
        }
    }
}