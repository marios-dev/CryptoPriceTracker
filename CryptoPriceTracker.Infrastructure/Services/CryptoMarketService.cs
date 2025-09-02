using CryptoPriceTracker.Domain.Entities;
using CryptoPriceTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPriceTracker.Infrastructure.Services
{
    public class CryptoMarketService : ICryptoMarketService
    {
        private readonly HttpClient _httpClient;
        public CryptoMarketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.coingecko.com");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "CryptoPriceTrackerApp");
        }
        public async Task<List<Coin>> GetTop100Cryptos()
        {
            var url = "api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false";
            var response = await _httpClient.GetFromJsonAsync<List<Coin>>(url);

            if (response != null)
            {
                return response.ToList();
            }
            else
            {
                return new List<Coin>();
            }
        }
    }
}
