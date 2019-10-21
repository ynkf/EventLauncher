using Eventlauncher.Web.Models.SvcModels;
using Eventlauncher.Web.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Eventlauncher.Web.Services
{
    public class MockCalendarService : ICalendarService
    {
        public Task<IReadOnlyCollection<Appointment>> GetAllAppointmentsForRooms()
        {
            var appointments = CreateFakeAppointments(10).ToList();

            return Task.FromResult<IReadOnlyCollection<Appointment>>(new ReadOnlyCollection<Appointment>(appointments));
        }

        private IEnumerable<Appointment> CreateFakeAppointments(int count)
        {
            foreach (var i in Enumerable.Range(1, count))
            {
                yield return new Appointment
                {
                    DateTime = DateTime.Now.AddMinutes(i * 2),
                    Room = new MeetingRoom
                    {
                        RoomDesignation = $"Meeting-Raum #{i}",
                        RoomMailAddress = $"room{i}@example.com",
                        Computer = new Computer { IpAddress = $"192.168.1.1{i}" }
                    }
                };
            }
        }
    }
}