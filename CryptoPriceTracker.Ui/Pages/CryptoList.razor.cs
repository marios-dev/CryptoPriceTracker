using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace CryptoPriceTracker.Ui.Pages
{
    public partial class CryptoList
    {
        private List<Coin>? cryptos;
        private string? selectedOrder = "marketcap";
        private DateTime lastUpdated;
        private bool isLoading = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                isLoading = true;
                await LoadData();
            }

            finally
            {
                isLoading = false;
            }
        }

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
        public async Task LoadData()
        {
            var client = new HttpClient();
            var starter = client.BaseAddress = new Uri("https://api.coingecko.com");
            client.DefaultRequestHeaders.Add("User-Agent", "CryptoPriceTrackerApp");
            var url = "api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false";
            var list = await client.GetFromJsonAsync<List<Coin>>(url);
            lastUpdated = DateTime.Now; // timestamp of the latest update
            if (list != null)
            {
                cryptos = selectedOrder?.ToLower() switch
                {
                    "price" => list.OrderByDescending(c => c.CurrentPrice).ToList(),
                    "marketcap" => list.OrderByDescending(c => c.MarketCap).ToList(),
                    "rank" => list.OrderBy(c => c.MarketCapRank).ToList(),
                    _ => list
                };
            }
            else
            {
                cryptos = new List<Coin>();
            }
        }
        private async Task RefreshData()
        {
            await LoadData();
        }
    }
}
