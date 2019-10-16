using System.Collections.Generic;
using System.Threading.Tasks;
using Eventlauncher.Web.Models.SvcModels;

namespace Eventlauncher.Web.Services.Abstractions
{
    public interface ICalendarService
    {
        Task<IReadOnlyCollection<Appointment>> GetAllAppointmentsForRooms();
    }
}
