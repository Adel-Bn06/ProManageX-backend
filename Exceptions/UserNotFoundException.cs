namespace SmartTasks.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException() : base("User Not Found Exception")
    {
        
    }
}
