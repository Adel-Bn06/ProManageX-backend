namespace SmartTasks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController(IProjectService service) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetAllProjects()
        {
            var AllProjects = service.GetAllProjects();
            return Ok(AllProjects);
        }
        [HttpGet("{id}")]
        public ActionResult<Project> GetProjectById(int id)
        {
            var ProjectById = service.GetProjectById(id);
            return Ok(ProjectById);
        }
        [HttpPost]
        public ActionResult<Project> AddProject(CreateProjectDto createProjectDto)
        {
            if (string.IsNullOrWhiteSpace(createProjectDto.Name))
                return BadRequest("Project name is required!");
            var AddProject = service.AddProject(createProjectDto);
            return Ok(AddProject);
        }
        [HttpPut("{id}")]
        public ActionResult<Project> UpdateProjectById(int id, ProjectDto projectDto) 
        { 
            var project = service.GetProjectById(id);
            return project;
        }
        [HttpDelete("{id}")]
        public ActionResult<Project> DeleteProjectById(int id) 
        { 
            var delete = service.DeleteProjectById(id);
            return delete;
        }
    }
}
