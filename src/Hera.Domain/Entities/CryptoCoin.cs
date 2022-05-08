namespace Hera.Domain.Entities
{
    public class CryptoCoin
    {
        public int Id { get; set; }
        public long? MarketCapRanking { get; set; }
        public String Name { get; set; }
        public String Symbol { get; set; }
        public double? CurrentPrice { get; set; }
        public double? PercentChange7D { get; set; }
        public long? MarketCap { get; set; }
        public double? PercentChange24H { get; set; }
        public long? MaxSupply { get; set; }
        public long? CirculatingSupply { get; set; }
        public long? TotalSupply { get; set; }
        public long? Volume24h { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }
}
