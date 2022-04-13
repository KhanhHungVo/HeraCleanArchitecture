using Hera.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hera.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CoinMarketCapController : ControllerBase
    {
        private readonly ICoinMarketCapClient _coinMarketCapClient;
        private readonly ILogger _logger;

        public CoinMarketCapController(ICoinMarketCapClient cryptoClient, ILogger<CoinMarketCapController> logger
        ) 
        {
            _coinMarketCapClient = cryptoClient;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _coinMarketCapClient.makeAPICall();
            _logger.LogInformation("test");
            return Ok(result);
        }

        [Route("list-coins")]
        [HttpGet]
        public async Task<IActionResult> GetListCoins(int start = 1, int limit = 50, string sortColumn = "MarketCap", string sortOrder = "")
        {
            var result = await _coinMarketCapClient.GetListCoinBasicInfo(start, limit, sortColumn, sortOrder);
            return Ok(result);
        }

        [Route("coin")]
        [HttpGet]
        public async Task<IActionResult> GetCoinBasicInfo(string symbol)
        {
            var result = await _coinMarketCapClient.GetCoinBasicInfo(symbol);
            return Ok(result);
        }

    }
}
