using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoCurrency
{
    class CoinGeckoAPI
    {
        public CoinGeckoAPI() { }

        public async Task<List<Coins>> GetTopCoins()
        {
            List<Coins> data = await LoadTopCoins();
            return data;
        }

        private async Task<List<Coins>> LoadTopCoins() {
            List<Coins> data;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36");
                    client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                    MessageBox.Show("1");
                    string apiUrl = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1&sparkline=false&locale=en";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonSerializer.Deserialize<List<Coins>>(content);
                        return data;
                    }
                    else
                    {
                        MessageBox.Show(response.StatusCode.ToString());
                        data = null;
                        return data;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    data = null;
                    return data;
                }
            }
        }
    }
}
