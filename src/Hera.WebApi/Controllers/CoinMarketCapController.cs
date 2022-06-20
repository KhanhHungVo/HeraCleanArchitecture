using Hera.Application.Common.Interfaces;
using Hera.Application.Crypto.Commands.RecordCryptoCoins;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hera.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CoinMarketCapController : ControllerBase
    {
        private readonly ICoinMarketCapService _coinMarketCapService;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public CoinMarketCapController(ICoinMarketCapService coinMarketCapService, ILogger<CoinMarketCapController> logger
, IMediator mediator)
        {
            _coinMarketCapService = coinMarketCapService;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _coinMarketCapService.makeAPICall();
            _logger.LogInformation("test calling to coin market cap api ");
            return Ok(result);
        }

        [Route("list-coins")]
        [HttpGet]
        public async Task<IActionResult> GetListCoins(int start = 1, int limit = 50, string sortColumn = "MarketCap", string sortOrder = "")
        {
            var result = await _coinMarketCapService.GetListCoinBasicInfo(start, limit, sortColumn, sortOrder);
            return Ok(result);
        }

        [Route("coin")]
        [HttpGet]
        public async Task<IActionResult> GetCoinBasicInfo(string symbol)
        {
            var result = await _coinMarketCapService.GetCoinBasicInfo(symbol);
            return Ok(result);
        }

        [Route("record-crypto-coins/{number}")]
        [HttpPost]
        public async Task<IActionResult> RecordCryptoCoin(int number)
        {
            var command = new RecordCryptoCommand {
                Number = number
            };
            return Ok(await _mediator.Send(command));
        }
    }
}
