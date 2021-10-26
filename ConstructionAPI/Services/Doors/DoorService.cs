using ConstructionAPI.Models;
using ConstructionAPI.Repository.Doors;
using ConstructionAPI.Repository.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionAPI.Services.Doors
{
    public class DoorService: IDoorService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IDoorRepository _doorRepository;

        public DoorService(IDoorRepository doorRepository, IProjectRepository projectRepository)
        {
            _doorRepository = doorRepository;
            _projectRepository = projectRepository;
        }

        public Task<Door> CreateDoor(Door doors)
        {
            return _doorRepository.CreateDoor(doors);
        }

        public Task DeleteDoor(string id)
        {
            return _doorRepository.DeleteDoor(id);
        }

        public Task<List<Door>> GetAllDoors()
        {
            return _doorRepository.GetAllDoors();
        }

        public Task<Door> GetDoorById(string id)
        {
            return _doorRepository.GetDoorById(id);
        }

        public Task<List<Door>> GetDoorsByProjectID(string id)
        {
            return _doorRepository.GetDoorsByProjectID(id);
        }

        public Task UpdateDoor(string id, Door doors)
        {
            doors.Done = CheckComponentAttached(doors);
            return _doorRepository.UpdateDoor(id, doors);
        }

        private bool CheckComponentAttached(Door doors)
        {
            if (doors.Lock.isLockComplete == true && doors.Cylinder.isCylinderCompleted == true && doors.Frame.isFrameCompleted == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
