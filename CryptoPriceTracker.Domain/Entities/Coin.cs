using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoPriceTracker.Domain.Entities
{
    public class Coin
    {
        [JsonPropertyName("market_cap_rank")]
        public int MarketCapRank { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("current_price")]
        public decimal CurrentPrice { get; set; }
        [JsonPropertyName("market_cap")]
        public decimal MarketCap { get; set; }
    }
}
