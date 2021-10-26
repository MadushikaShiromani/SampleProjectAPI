using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionAPI.Models;

namespace ConstructionAPI.Services.Doors
{
    public interface IDoorService
    {
        Task<List<Door>> GetAllDoors();
        Task<Door> GetDoorById(string id);
        Task<Door> CreateDoor(Door doors);
        Task UpdateDoor(string id, Door doors);
        Task DeleteDoor(string id);

        Task<List<Door>> GetDoorsByProjectID(string id);
    }
}
