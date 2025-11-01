namespace Store.G04.Domain.Entities.Baskets
{
    public class CustomerBasket
    {
        public int Id { get; set; }
        public IEnumerable<BasketItem> Items { get; set; }

    }
}
