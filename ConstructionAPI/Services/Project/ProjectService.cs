using ConstructionAPI.Models;
using ConstructionAPI.Repository.Doors;
using ConstructionAPI.Repository.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionAPI.Services.Project
{
    public class ProjectService : IProjectInterface
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IDoorRepository doorRepository, IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<Projects> CreateProject(Projects books)
        {
            return _projectRepository.CreateProject(books);
        }

        public Task DeleteProject(string id)
        {
            return _projectRepository.DeleteProject(id);
        }

        public Task<List<Projects>> GetAllProjects()
        {
            return _projectRepository.GetAllProjects();
        }

        public Task<Projects> GetProjectById(string id)
        {
            return _projectRepository.GetProjectById(id);
        }

        public Task UpdateProject(string id, Projects projects)
        {
            return _projectRepository.UpdateProject(id, projects);
        }
    }
}
