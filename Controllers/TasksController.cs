using System.Threading.Tasks;

namespace SmartTasks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TasksController(AppDbContext context) 
        { 
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> GetAllTasks() 
        { 
            var Tasks = _context.Tasks.ToList();
            return Ok(Tasks);
        }
        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetTaskById(int id)
        {
            var FindTasks = _context.Tasks.Find(id);
            if(FindTasks == null)
            {
                return NotFound();
            }
            return Ok(FindTasks);
        }
        [HttpPost]
        public ActionResult<TaskItem> AddTask(CreateTaskItemDto createTaskItemDto)
        {
            var taskItem = new TaskItem
            {
                Title = createTaskItemDto.Title,
                ProjectId = createTaskItemDto.ProjectId,
            };
            if((_context.Tasks.FirstOrDefault(title => title.Title == createTaskItemDto.Title) != null)) { return BadRequest("Title is already found !"); }
            _context.Tasks.Add(taskItem);
            _context.SaveChanges();
            return Ok(taskItem);
        }
        [HttpPut("{id}")]
        public ActionResult<TaskItem> UpdateTaskById(int id, TaskDto taskDto)
        {
            var FindTask = _context.Tasks.Find(id);
            if (FindTask == null) { return NotFound(); }
            FindTask.Title = taskDto.Title;
            FindTask.ProjectId = taskDto.ProjectId;
            FindTask.IsCompleted = taskDto.IsCompleted;
            _context.SaveChanges();
            return Ok(FindTask);
        }
        [HttpDelete("{id}")]
        public ActionResult<TaskItem> DeleteTaskById(int id)
        {
            var FindTask = _context.Tasks.Find(id);
            if (FindTask == null) return NotFound("Task not found!");
            _context.Tasks.Remove(FindTask);
            _context.SaveChanges();
            return Ok(FindTask);
        }


    }
}
