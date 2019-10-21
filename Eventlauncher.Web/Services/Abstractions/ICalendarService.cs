using Eventlauncher.Web.Models.SvcModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventlauncher.Web.Services.Abstractions
{
    public interface ICalendarService
    {
        Task<IReadOnlyCollection<Appointment>> GetAllAppointmentsForRooms();
    }
}