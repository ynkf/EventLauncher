using System.ComponentModel.DataAnnotations;

namespace Eventlauncher.Web.Models.EntityModels
{
    public class Computer
    {
        [Key]
        public int Id { get; set; }

        public string IpAddress { get; set; }
    }
}
