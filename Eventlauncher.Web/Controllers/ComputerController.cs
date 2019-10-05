using Eventlauncher.Web.Data.Repositories.Abstractions;
using Eventlauncher.Web.Models.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventlauncher.Web.Controllers
{
    [ApiController]
    [Route("api/computer")]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerRepository _computerRepository;

        public ComputerController(IComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
        }

        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _computerRepository.GetAllAsync());
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(Computer computer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _computerRepository.CreateAsync(computer.ToEntityModel());

            return Ok();
        }

        [Route("edit/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Computer computer)
        {
            if (id != computer.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var toUpdate = await _computerRepository.GetByIdAsync(id);
            if (toUpdate == null)
                return NotFound();

            await _computerRepository.UpdateAsync(computer.ToEntityModel());

            return Ok();
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var toDelete = await _computerRepository.GetByIdAsync(id);
            if (toDelete == null)
                return NotFound();

            await _computerRepository.DeleteAsync(toDelete);

            return Ok();
        }
    }
}
