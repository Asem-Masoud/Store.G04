namespace Store.G04.Domain.Exceptions
{
    public class BasketNotFoundException(string id) :
        NotFoundException($"Basket with id {id} Not Found!!")
    {
    }
}
