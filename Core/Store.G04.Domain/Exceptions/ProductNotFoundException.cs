namespace Store.G04.Domain.Exceptions
{
    public class ProductNotFoundException(int id) : NotFoundException($"Product with {id} Not Found!!")
    {

    }
}
