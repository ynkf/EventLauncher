using System.ComponentModel.DataAnnotations;

namespace Eventlauncher.Web.Models.EntityModels
{
    public class MeetingRoom
    {
        [Key]
        public int Id { get; set; }

        public string RoomDesignation { get; set; }

        public string RoomMailAddress { get; set; }

        public int ComputerId { get; set; }

        public Computer Computer { get; set; }
    }
}