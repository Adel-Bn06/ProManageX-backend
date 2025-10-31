

namespace SmartTasks.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var ListOfUsers = userService.GetUsers();
        return Ok(ListOfUsers);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var FindUser = userService.GetUserById(id);
        return Ok(FindUser);
    }

    [HttpPost]
    public ActionResult<User> AddUser(CreateUserDto createUserDto)
    {
        if(createUserDto == null)
        {
            throw new ValidationException("User Didn\'t create !");
        }
        var user = userService.AddUser(createUserDto);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public ActionResult<User> UpdateUserById(int id, UserDto userDto)
    {
        var user = userService.UpdateUserById(id, userDto);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public ActionResult<User> DeleteUserById(int id)
    {
        var FindUser = userService.DeleteUserById(id);
        return Ok(FindUser);
    }
}
