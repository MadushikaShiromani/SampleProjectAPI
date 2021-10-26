using ConstructionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionAPI.Services.Project
{
    public interface IProjectInterface
    {
        Task<List<Projects>> GetAllProjects();
        Task<Projects> GetProjectById(string id);
        Task<Projects> CreateProject(Projects books);
        Task UpdateProject(string id, Projects books);
        Task DeleteProject(string id);
    }
}
