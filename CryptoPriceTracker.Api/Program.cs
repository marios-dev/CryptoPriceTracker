using CryptoPriceTracker.Application.Services;
using CryptoPriceTracker.Domain.Interfaces;
using CryptoPriceTracker.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddHttpClient<ICryptoPriceService, CoinGeckoService>();
builder.Services.AddHttpClient<ICryptoMarketService, CryptoMarketService>();
builder.Services.AddScoped<CryptoPriceAppService>();
builder.Services.AddScoped<CryptoMarketService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(options =>
{
    
    options.AddPolicy("AllowBlazorDev", policy =>
    {
        policy
            .WithOrigins("https://localhost:5001") // your Blazor app URL
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

//Cors
app.UseCors("AllowBlazorDev");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapGet("/api/CryptoList", async (CryptoMarketService service) =>
{
    try
    {
        var list = await service.GetTop100Cryptos();
        return Results.Ok(list);
    }
    catch (Exception)
    {

        throw;
    }
});

app.MapGet("/api/prices/{symbol}", async (string symbol, CryptoPriceAppService service) =>
{
    try
    {
        var price = await service.GetPriceAsync(symbol);
        return Results.Ok(price);
    }
    catch (Exception ex)
    {
        return Results.NotFound(new { error = ex.Message });
    }
})
.WithName("GetCryptoPrice")
.WithOpenApi();

app.Run();