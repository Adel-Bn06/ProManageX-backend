
using SmartTasks.DTOs;
using SmartTasks.Exceptions;

namespace SmartTasks.Services.Implementations;

public class UserService(AppDbContext context) : IUserService
{
    public List<User> GetUsers()
    {
        return context.Users.ToList();
    }

    public User GetUserById(int id)
    {
        var user = context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        return user;
    }
    public User AddUser(CreateUserDto createUserDto)
    {
        var user = new User
        {
            FullName = createUserDto.FullName,
            Email = createUserDto.Email,
            Password = createUserDto.Password,
        };
        var existEmail = context.Users.FirstOrDefault(user => user.Email == createUserDto.Email);
        if (existEmail != null)
        {
            throw new Exception("Email is Exist Enter Another Email Bro !");
        }
        var HashPassowrd = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);
        user.Password = HashPassowrd;
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }

    public User UpdateUserById(int id,UserDto userDto)
    {
        var FindUser = context.Users.Find(id);
        if (FindUser == null)
        {
            throw new Exception("User not found !");
        }
        FindUser.FullName = userDto.FullName;
        FindUser.Email = userDto.Email;
        context.SaveChanges();
        return FindUser;
    }

    public User DeleteUserById(int id)
    {
        var FindUser = context.Users.Find(id);
        if (FindUser == null)
        {
            throw new Exception("User not found !");
        }
        context.Users.Remove(FindUser);
        context.SaveChanges();
        return FindUser;
    }
}
