namespace Property.Domain.Exceptions
{
    public class PropertyDoesntExistException(string message) : Exception(message)
    {
    }
}
