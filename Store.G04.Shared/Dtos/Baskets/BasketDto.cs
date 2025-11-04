namespace Store.G04.Shared.Dtos.Baskets
{
    public class BasketDto
    {
        public string Id { get; set; }
        public IEnumerable<BasketItemDto> Items { get; set; }
    }
}
