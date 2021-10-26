using ConstructionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionAPI.Repository.Project
{
    public interface IProjectRepository
    {
        Task<List<Projects>> GetAllProjects();
        Task<Projects> GetProjectById(string id);
        Task<Projects> CreateProject(Projects projects);
        Task UpdateProject(string id, Projects projects);
        Task DeleteProject(string id);
    }
}
