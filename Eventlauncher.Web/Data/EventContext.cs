using Eventlauncher.Web.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Eventlauncher.Web.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Computer> Computers { get; set; }

        public DbSet<MeetingRoom> MeetingRooms { get; set; }
    }
}
