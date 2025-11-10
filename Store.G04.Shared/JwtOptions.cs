namespace Store.G04.Shared
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecurityKey { get; set; }
        public double DurationInDays { get; set; }
    }
}