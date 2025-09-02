using CryptoPriceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPriceTracker.Domain.Interfaces
{
    public interface ICryptoMarketService
    {
        Task<List<Coin>> GetTop100Cryptos();
    }
}
