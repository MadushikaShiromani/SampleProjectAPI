using ConstructionAPI.Configuration;
using ConstructionAPI.Models;
using ConstructionAPI.Repository.Project;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionAPI.Repository.Doors
{
    public class DoorRepository: IDoorRepository
    {
        private readonly IMongoCollection<Door> _doors;
        
        public readonly DbSettings _settings;

        private readonly IProjectRepository projectRepository;

        public DoorRepository(IOptions<DbSettings> settings, IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _doors = database.GetCollection<Door>("Door");
        }

        public async Task<Door> CreateDoor(Door doors)
        {
            await _doors.InsertOneAsync(doors);
            return doors;
        }

        public async Task DeleteDoor(string id)
        {
            await _doors.DeleteOneAsync(c => c.id == id && c.Done != true);
        }

        public async Task<List<Door>> GetAllDoors()
        {
            var client = new MongoClient(_settings.ConnectionString);

            var projects = await this.projectRepository.GetAllProjects();
            var doors = await _doors.Find(c => true).ToListAsync();

            doors.Select(x => x.Project_Name = projects.Find(r => r.id == x.Project_Id).Project_Name).ToList();
            return await Task.FromResult(doors.ToList());
        }

        public async Task<Door> GetDoorById(string id)
        {
            return await _doors.Find<Door>(c => c.id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateDoor(string id, Door doors)
        {
            //var filter = Builders<Door>.Filter.Eq(t => t.id, id);
            //var update = Builders<Door>.Update
            //    .Set(t => t.Building_Name, doors.Building_Name)
            //    .Set(t => t.Room_Name, doors.Room_Name)
            //    .Set(t => t.Width, item.isActive)
            //    .Set(t => t.templateFieldsData, item.templateFieldsData);

            //var updateResult = coll.UpdateOne(filter, update);
            
            await _doors.ReplaceOneAsync(C => C.id == id, doors);
        }

        public async Task<List<Door>> GetDoorsByProjectID(string id)
        {
            var projects = await this.projectRepository.GetAllProjects();
            var doors = await _doors.Find(c => c.Project_Id == id).ToListAsync();

            doors.Select(x => x.Project_Name = projects.Find(r => r.id == x.Project_Id).Project_Name).ToList();
            return await Task.FromResult(doors.ToList());
        }
    }
}
