using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Eventlauncher.Web.Models.SvcModels;
using Eventlauncher.Web.Services.Abstractions;

namespace Eventlauncher.Web.Services
{
    public class MockCalendarService : ICalendarService
    {
        public Task<IReadOnlyCollection<Appointment>> GetAllAppointmentsForRooms()
        {
            var appointments = new List<Appointment>();

            return Task.FromResult<IReadOnlyCollection<Appointment>>(new ReadOnlyCollection<Appointment>(appointments));
        }
    }
}
