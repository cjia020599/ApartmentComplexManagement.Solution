using FluentResults;

namespace Property.Application.Errors
{
    public class PropertyNotExistingError(string message) : Error(message) 
    {
    }
}
