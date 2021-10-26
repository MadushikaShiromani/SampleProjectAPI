using ConstructionAPI.Models;
using ConstructionAPI.Repository.Doors;
using ConstructionAPI.Services.Doors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        private readonly IDoorService _DoorService;
        public DoorController(IDoorService DoorService)
        {
            _DoorService = DoorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _DoorService.GetAllDoors());
        }
        [HttpGet("{id:length(24)}", Name = "getDoorByID")]
        public async Task<IActionResult> Get(string id)
        {
            var door = await _DoorService.GetDoorById(id);
            if (door == null)
            {
                return NotFound();
            }
            return Ok(door);
        }

        [HttpGet("GetDoorsByProjectID/{id:length(24)}", Name = "getDatabyID")]
        public async Task<IActionResult> GetDoorsByProjectID(string id)
        {
            var door = await _DoorService.GetDoorsByProjectID(id);
            if (door == null)
            {
                return NotFound();
            }
            return Ok(door);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Door Doors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _DoorService.CreateDoor(Doors);
            //return Ok(Doors.id);
            return Ok();
        }

        [HttpPut("{id:length(24)}", Name = "UpdateDoor")]
        public async Task<IActionResult> Update(string id, Door Doors)
        {
            var book = await _DoorService.GetDoorById(id);
            if (book == null)
            {
                return NotFound();
            }
            await _DoorService.UpdateDoor(id, Doors);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteDoor")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _DoorService.GetDoorById(id);
            if (book == null)
            {
                return NotFound();
            }
            await _DoorService.DeleteDoor(book.id);
            return NoContent();
        }
    }
}
