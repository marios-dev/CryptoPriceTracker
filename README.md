# 📈 Crypto Price Tracker

A simple .NET 9 + Blazor WebAssembly** project built with **Clean Architecture** principles to practice modern .NET development, API integration, and frontend skills.  

This app fetches the Top 100 cryptocurrencies** from the CoinGecko API (https://www.coingecko.com/en/api) and displays them in a Blazor WebAssembly UI with ordering support (by Market Cap, Price, or Rank).  

## 🚀 Features
- Minimal API backend in .NET 9  
- Blazor WebAssembly frontend for displaying results  
- Fetches top 100 cryptos from CoinGecko  
- Ordering support (Market Cap, Price, Rank)  
- Clean Architecture setup:
  - CryptoPriceTracker.Api → Minimal API  
  - CryptoPriceTracker.Application → Business logic  
  - CryptoPriceTracker.Infrastructure → External API integration  
  - CryptoPriceTracker.Domain → Entities & Interfaces  
  - CryptoPriceTracker.UI → Blazor WebAssembly frontend  

---

### 🏗️ Project Structure

CryptoPriceTracker
│
├── CryptoPriceTracker.Api # Presentation layer (Minimal API)
├── CryptoPriceTracker.Application # Application logic
├── CryptoPriceTracker.Infrastructure # External services (CoinGecko API)
├── CryptoPriceTracker.Domain # Entities & Interfaces
└── CryptoPriceTracker.UI # Blazor WebAssembly frontend

#### To run the API
1. Clone the repo
2. Open CryptoPriceTracker.Api in Visual Studio and run it (IIS Express or Kestrel). It will expose endpoints like: https://localhost:5001/api/CryptoList
3. Open CryptoPriceTracker.UI (Blazor WebAssembly project) and run it. It will connect to the API and show the crypto list or show the price of any token in the top100 individually. (for now)


##### 🛠️ Tech Stack

.NET 9
Blazor WebAssembly
Minimal API
CoinGecko API
Clean Architecture
