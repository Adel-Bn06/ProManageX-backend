
namespace SmartTasks.Services.Implementations
{
    public class ProjectService(AppDbContext _context) : IProjectService
    {
        public List<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }
        public Project GetProjectById(int id)
        {
            var ProjectById = _context.Projects.FirstOrDefault(x => x.Id == id);
            if (ProjectById == null) { throw new Exception("Project NotFound !"); }
            return ProjectById;
        }
        public Project AddProject(CreateProjectDto createProjectDto)
        {
            var project = new Project
            {
                Name = createProjectDto.Name,
                UserId = createProjectDto.UserId,
            };
            if (_context.Projects.Any(p => p.Name == createProjectDto.Name))
            {
                throw new ValidationException("This Project name is already exist !");
            }
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }
        public Project UpdateProjectById(int id, ProjectDto projectDto)
        {
            var FindProjectById = _context.Projects.FirstOrDefault(x => x.Id == id);
            if (FindProjectById == null) { throw new Exception("Project NotFound !"); }
            FindProjectById.Name = projectDto.Name;
            FindProjectById.UserId = projectDto.UserId;
            _context.SaveChanges();
            return FindProjectById;
        }
        public Project DeleteProjectById(int id)
        {
            var FindProjectToDelete = _context.Projects.FirstOrDefault(y => y.Id == id);
            if (FindProjectToDelete == null) { throw new Exception("Project NotFound !"); }
            _context.Projects.Remove(FindProjectToDelete);
            _context.SaveChanges();
            return FindProjectToDelete;
        }
    }
}
