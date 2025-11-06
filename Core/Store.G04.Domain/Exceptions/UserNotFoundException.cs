namespace Store.G04.Domain.Exceptions
{
    public class UserNotFoundException(string email) :
        NotFoundException($"User with email {email} Not Found!!")
    { }
}