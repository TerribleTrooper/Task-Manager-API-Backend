namespace Task_Manager_API_Backend.Exceptions;

public class ValidationException : AppException
{
    public ValidationException(string message) : base(message)
    {
    }
}