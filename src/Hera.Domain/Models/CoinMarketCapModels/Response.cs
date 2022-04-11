using Newtonsoft.Json;

namespace Hera.Domain.Models.CoinMarketCapModels
{
    public class Response<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}
