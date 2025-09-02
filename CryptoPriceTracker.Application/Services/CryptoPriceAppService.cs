using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoPriceTracker.Domain.Entities;
using CryptoPriceTracker.Domain.Interfaces;

namespace CryptoPriceTracker.Application.Services
{
    public class CryptoPriceAppService
    {
        private readonly ICryptoPriceService _cryptoPriceService;

        public CryptoPriceAppService(ICryptoPriceService cryptoPriceService)
        {
            _cryptoPriceService = cryptoPriceService;
        }

        public Task<CryptoPrice> GetPriceAsync(string symbol) =>
            _cryptoPriceService.GetPriceAsync(symbol);

    }
}
