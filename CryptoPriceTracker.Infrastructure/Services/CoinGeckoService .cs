using System.Net.Http.Json;
using CryptoPriceTracker.Domain.Entities;
using CryptoPriceTracker.Domain.Interfaces;

namespace CryptoPriceTracker.Infrastructure.Services
{
    public class CoinGeckoService : ICryptoPriceService
    {
        private readonly HttpClient _httpClient;

        public CoinGeckoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
        }

        private static readonly Dictionary<string, string> SymbolToId = new(StringComparer.OrdinalIgnoreCase)
        {
            { "BTC", "bitcoin" },
            { "ETH", "ethereum" },
            { "SOL", "solana" },
            { "DOGE", "dogecoin" },
            { "ADA", "cardano" }
        };

        public async Task<CryptoPrice> GetPriceAsync(string symbol)
        {
            if (!SymbolToId.TryGetValue(symbol, out var id))
            {
                throw new Exception($"Symbol {symbol} is not supported.");
            }

            var url = $"simple/price?ids={id}&vs_currencies=usd";
            var response = await _httpClient.GetFromJsonAsync<Dictionary<string, Dictionary<string, decimal>>>(url);

            if (response != null && response.ContainsKey(id))
            {
                return new CryptoPrice
                {
                    Symbol = symbol.ToUpper(),
                    PriceUsd = response[id]["usd"],
                    RetrievedAt = DateTime.UtcNow
                };
            }

            throw new Exception($"Price for {symbol} not found.");
        }
    }
}
