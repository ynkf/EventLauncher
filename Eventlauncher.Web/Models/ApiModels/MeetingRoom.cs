using System.ComponentModel.DataAnnotations;

namespace Eventlauncher.Web.Models.ApiModels
{
    public class MeetingRoom
    {
        public int Id { get; set; }

        [Required]
        public string RoomDesignation { get; set; }

        [Required]
        public string RoomMailAddress { get; set; }

        public int ComputerId { get; set; }

        public EntityModels.MeetingRoom ToEntityModel() =>
             new EntityModels.MeetingRoom
             {
                 Id = Id,
                 RoomDesignation = RoomDesignation,
                 RoomMailAddress = RoomMailAddress,
                 ComputerId = ComputerId
             };
    }
}