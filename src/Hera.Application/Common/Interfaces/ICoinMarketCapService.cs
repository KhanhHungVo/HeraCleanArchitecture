using Hera.Domain.Entities;
using Hera.Domain.Models.CoinMarketCapModels;

namespace Hera.Application.Common.Interfaces
{
    public interface ICoinMarketCapService
    {
        Task<Response<List<ListingLatestDataRs>>> makeAPICall();
        Task<List<CryptoCoin>> GetListCoinBasicInfo(int start, int limit, string sortColumn = "MarketCap", string sortOrder = "");
        Task<CryptoCoin> GetCoinBasicInfo(string symbol);
    }
}
