using ConstructionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionAPI.Repository.Doors
{
    public interface IDoorRepository
    {
        Task<List<Door>> GetAllDoors();
        //Task<List<Door>> GetAllDoors();
        Task<Door> GetDoorById(string id);
        Task<Door> CreateDoor(Door doors);
        Task UpdateDoor(string id, Door doors);
        Task DeleteDoor(string id);
        Task<List<Door>> GetDoorsByProjectID(string id);
    }
}
