using DaHo.Library.AspNetCore.Data.Repositories.EntityFramework;
using Eventlauncher.Web.Data.Repositories.Abstractions;
using Eventlauncher.Web.Models.EntityModels;

namespace Eventlauncher.Web.Data.Repositories
{
    public class ComputerRepository : GenericEntityRepository<Computer, EventContext>, IComputerRepository
    {
        public ComputerRepository(EventContext context) : base(context)
        {
        }
    }
}
