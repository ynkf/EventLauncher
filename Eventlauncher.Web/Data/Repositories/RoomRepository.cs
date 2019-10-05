using DaHo.Library.AspNetCore.Data.Repositories.EntityFramework;
using Eventlauncher.Web.Data.Repositories.Abstractions;
using Eventlauncher.Web.Models.EntityModels;

namespace Eventlauncher.Web.Data.Repositories
{
    public class RoomRepository : GenericEntityRepository<MeetingRoom, EventContext>, IRoomRepository
    {
        public RoomRepository(EventContext context) : base(context)
        {
        }
    }
}
