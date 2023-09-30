using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoCurrency.Model
{
    public class CoinCapAPI
    {
        public CoinCapAPI() { }

        public List<CoinHistory> GetCoinHistories(string id)
        {
            List<CoinHistory> data = GenerateCoinHistory(id).Result;
            return data;
        }

        private async Task<List<CoinHistory>> GenerateCoinHistory(string id)
        {
            List<CoinHistory> data = new List<CoinHistory>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36");
                    client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                    string apiUrl = $"https://api.coincap.io/v2/assets/{id}/history?interval=d1&start={GetTimeStampOneMonthAgo()}&end={GetTimeStampToday()}"; 
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();

                        using (JsonDocument doc = JsonDocument.Parse(content))
                        {
                            JsonElement root = doc.RootElement;
                            JsonElement dataElement = root.GetProperty("data");
                            if (dataElement.ValueKind == JsonValueKind.Array)
                            {
                                foreach (JsonElement item in dataElement.EnumerateArray())
                                {
                                    CoinHistory coinHistory = JsonSerializer.Deserialize<CoinHistory>(item.GetRawText());
                                    data.Add(coinHistory);
                                }
                            }
                        }
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


        private long GetTimeStampToday()
        {
            DateTime today = DateTime.Now;
            long timestampToday = (long)(today - new DateTime(1970, 1, 1)).TotalMilliseconds;
            return timestampToday;
        }

        private long GetTimeStampOneMonthAgo()
        {
            DateTime today = DateTime.Now;
            DateTime oneMonthAgo = today.AddMonths(-1);
            long timestampOneMonthAgo = (long)(oneMonthAgo - new DateTime(1970, 1, 1)).TotalMilliseconds;
            return timestampOneMonthAgo;

        }
    }
}
