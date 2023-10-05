using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoCurrency.Model
{
    public class CoinCapAPI
    {
        private const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36";
        private const string XRequestedWith = "XMLHttpRequest";
        private static readonly HttpClient client = new HttpClient();

        public CoinCapAPI()
        {
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            client.DefaultRequestHeaders.Add("X-Requested-With", XRequestedWith);
        }

        public async Task<List<CoinHistory>> GetCoinHistories(string id)
        {
            return await GenerateCoinHistory($"https://api.coincap.io/v2/assets/{id}/history?interval=d1&start={GetTimeStampOneMonthAgo()}&end={GetTimeStampToday()}");
        }

        private async Task<List<CoinHistory>> GenerateCoinHistory(string apiUrl)
        {
            List<CoinHistory> data = new List<CoinHistory>();
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

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
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
            catch (Exception)
            {
                throw;
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