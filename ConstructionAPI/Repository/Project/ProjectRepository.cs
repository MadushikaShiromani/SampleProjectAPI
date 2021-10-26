using ConstructionAPI.Configuration;
using ConstructionAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionAPI.Repository.Project
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly IMongoCollection<Projects> _projects;
        public readonly DbSettings _settings;
        public ProjectRepository(IOptions<DbSettings> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _projects = database.GetCollection<Projects>("Project");
        }

        public async Task<Projects> CreateProject(Projects projects)
        {
            await _projects.InsertOneAsync(projects);
            return projects;
        }

        public async Task DeleteProject(string id)
        {
            await _projects.DeleteOneAsync(c => c.id == id);
        }

        public async Task<List<Projects>> GetAllProjects()
        {
            return await _projects.Find(c => true).ToListAsync();
        }

        public async Task<Projects> GetProjectById(string id)
        {
            return await _projects.Find<Projects>(c => c.id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateProject(string id, Projects books)
        {
            await _projects.ReplaceOneAsync(C => C.id == id, books);
        }
    }
}
