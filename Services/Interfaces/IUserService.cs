namespace SmartTasks.Services.Interfaces;

public interface IUserService
{
    public List<User> GetUsers();
    public User GetUserById(int id);
    public User AddUser(CreateUserDto createUserDto);
    public User UpdateUserById(int id, UserDto userDto);
    public User DeleteUserById(int id);
}
