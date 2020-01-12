using Eventlauncher.Web.Data.Repositories.Abstractions;
using Eventlauncher.Web.Models.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventlauncher.Web.Controllers
{
    [ApiController]
    [Route("api/room")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roomRepository.GetAllAsync());
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(MeetingRoom room)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _roomRepository.CreateAsync(room.ToEntityModel());

            return Ok();
        }

        [Route("edit/{id:int}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, MeetingRoom room)
        {
            if (id != room.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var toUpdate = await _roomRepository.GetByIdAsync(id);
            if (toUpdate == null)
                return NotFound();

            await _roomRepository.UpdateAsync(room.ToEntityModel());

            return Ok();
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var toDelete = await _roomRepository.GetByIdAsync(id);
            if (toDelete == null)
                return NotFound();

            await _roomRepository.DeleteAsync(toDelete);

            return Ok();
        }
    }
}