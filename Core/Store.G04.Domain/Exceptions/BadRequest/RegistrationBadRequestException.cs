namespace Store.G04.Domain.Exceptions.BadRequest
{
    public class RegistrationBadRequestException(List<string> errors) : BadRequestException(string.Join(", ", errors))
    {

    }
}