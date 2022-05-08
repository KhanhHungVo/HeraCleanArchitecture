namespace Hera.Domain.Entities
{
    public class UserFavorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CryptoCoinSymbol { get; set; }
    }
}
