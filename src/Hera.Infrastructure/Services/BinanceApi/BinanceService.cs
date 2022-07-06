using Hera.Application.Common.Interfaces;

namespace Hera.Infrastructure.Services.BinanceApi
{
    public class BinanceService : IBinanceService
    {
        public const string BASE_URL = "https://api.binance.com/api/v3";
        public async Task GetCoinLastestPrice(List<string> symbols){
            var _httpClient = new HttpClient {
                BaseAddress = new Uri(BASE_URL)
            };

        }
    }
}