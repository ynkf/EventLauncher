using Eventlauncher.Web.Data.Extensions;
using Eventlauncher.Web.Data.Repositories.Abstractions;
using Eventlauncher.Web.Models.EntityModels;

namespace Eventlauncher.Web.Data.Repositories
{
    public class ComputerRepository : GenericEntityRepositoryBase<Computer, EventContext>, IComputerRepository
    {
        public ComputerRepository(EventContext context) : base(context)
        {
        }
    }
}