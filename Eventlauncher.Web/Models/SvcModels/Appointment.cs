using System;

namespace Eventlauncher.Web.Models.SvcModels
{
    public class Appointment
    {
        public DateTime DateTime { get; set; }

        public MeetingRoom Room { get; set; }
    }
}