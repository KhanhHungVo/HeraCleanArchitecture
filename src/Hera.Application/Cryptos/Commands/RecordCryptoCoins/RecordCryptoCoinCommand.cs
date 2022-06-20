using Hera.Application.Common.Interfaces;
using MediatR;

namespace Hera.Application.Crypto.Commands.RecordCryptoCoins
{
    public class RecordCryptoCommand : IRequest
    {
        public  int Number { get; set; } 
    }
    public class RecordCryptoCommandHandler : IRequestHandler<RecordCryptoCommand>
    {
        private readonly ICoinMarketCapService _coinMarketCapService;
        private readonly ICryptoService _cryptoService;

        public RecordCryptoCommandHandler(ICoinMarketCapService coinMarketCapService, ICryptoService cryptoService)
        {
            _coinMarketCapService = coinMarketCapService;
            _cryptoService = cryptoService;
        }

        public async Task<Unit> Handle(RecordCryptoCommand request, CancellationToken cancellationToken)
        {
            var listCryptoCoins = await _coinMarketCapService.GetListCoinBasicInfo(1, request.Number);
            await _cryptoService.RecordCryptoCoins(listCryptoCoins);
            return Unit.Value;
        }
    }
}