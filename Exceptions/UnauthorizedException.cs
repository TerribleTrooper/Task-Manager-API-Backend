namespace Task_Manager_API_Backend.Exceptions;

public class UnauthorizedException : AppException
{
    public UnauthorizedException(string message = "Unauthorized")
        : base(message)
    {
    }
}