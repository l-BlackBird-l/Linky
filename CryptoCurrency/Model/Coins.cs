using CryptoCurrency.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoCurrency
{
   public class Coins
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("current_price")]
        public double CurrentPrice { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public double Price_change_percentage_24h { get; set; }

        [JsonPropertyName("high_24h")]
        public double High_24h { get; set; }

        [JsonPropertyName("low_24h")]
        public double Low_24h { get; set; }

        [JsonPropertyName("ath")]
        public double Ath { get; set; }

        [JsonPropertyName("ath_change_percentage")]
        public double Ath_change_percentage { get; set; }

        [JsonPropertyName("ath_date")]
        public DateTimeOffset? Ath_date { get; set; }

        [JsonPropertyName("atl")]
        public double Atl { get; set; }

        [JsonPropertyName("atl_change_percentage")]
        public double Atl_change_percentage { get; set; }

        [JsonPropertyName("atl_date")]
        public DateTimeOffset? Atl_date { get; set; }
        
        [JsonPropertyName("market_cap_rank")]
        public int Market_cap_rank { get; set; }

        public List<CoinHistory> Histories { get; set; }
    }
}
