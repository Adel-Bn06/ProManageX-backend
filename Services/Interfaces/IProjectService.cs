namespace SmartTasks.Services.Interfaces;


public interface IProjectService
    {
        public List<Project> GetAllProjects();
        public Project GetProjectById(int id);
        public Project AddProject(CreateProjectDto createProjectDto);
        public Project UpdateProjectById(int id, ProjectDto projectDto);
        public Project DeleteProjectById(int id);
    }

