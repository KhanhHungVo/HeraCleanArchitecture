using Hera.Domain.Entities;
using Hera.Domain.Models.CoinMarketCapModels;

namespace Hera.Application.Common.Interfaces
{
    public interface ICoinMarketCapClient
    {
        Task<Response<List<ListingLatestDataRs>>> makeAPICall();
        Task<List<CoinBasicInfo>> GetListCoinBasicInfo(int start, int limit, string sortColumn, string sortOrder);
        Task<CoinBasicInfo> GetCoinBasicInfo(string symbol);
    }
}
