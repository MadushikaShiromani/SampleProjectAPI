using ConstructionAPI.Models;
using ConstructionAPI.Repository.Project;
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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _projectRepository.GetAllProjects());
        }
        [HttpGet("{id:length(24)}", Name = "getProjectByID")]
        public async Task<IActionResult> Get(string id)
        {
            var book = await _projectRepository.GetProjectById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Projects projects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _projectRepository.CreateProject(projects);
            return Ok();
            //return Ok(projects.id);
        }

        [HttpPut("{id:length(24)}", Name = "UpdateProject")]
        public async Task<IActionResult> Update(string id, Projects projects)
        {
            var book = await _projectRepository.GetProjectById(id);
            if (book == null)
            {
                return NotFound();
            }
            await _projectRepository.UpdateProject(id, projects);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}", Name = "DeleteProject")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _projectRepository.GetProjectById(id);
            if (book == null)
            {
                return NotFound();
            }
            await _projectRepository.DeleteProject(book.id);
            return NoContent();
        }
    }
}
