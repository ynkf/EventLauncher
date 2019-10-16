namespace Eventlauncher.Web.Models.SvcModels
{
    public class MeetingRoom
    {

        public string RoomDesignation { get; set; }

        public string RoomMailAddress { get; set; }

        public int ComputerId { get; set; }

        public Computer Computer { get; set; }
    }
}
