using Eventlauncher.Web.Data.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventlauncher.Web.Controllers
{
    [ApiController]
    [Route("api/room")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await roomRepository.GetAllAsync());
        }
    }
}
