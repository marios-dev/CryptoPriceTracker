namespace CryptoPriceTracker.Domain.Entities
{
    public class CryptoPrice
    {
        public string Symbol { get; set; } = string.Empty;
        public decimal PriceUsd { get; set; }
        public DateTime RetrievedAt { get; set; } = DateTime.UtcNow;
    }
}
