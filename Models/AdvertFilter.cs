namespace RestfulApiExample.Models
{
    public class AdvertFilter
    {
        public int? CategoryId { get; set; }
        public decimal? Price { get; set; }
        public string? Gear { get; set; }
        public string? Fuel { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 30;
    }
}
