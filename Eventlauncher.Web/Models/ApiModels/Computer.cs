using System.ComponentModel.DataAnnotations;

namespace Eventlauncher.Web.Models.ApiModels
{
    public class Computer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string IpAddress { get; set; }

        public EntityModels.Computer ToEntityModel() => 
            new EntityModels.Computer 
            { 
                Id = Id, 
                IpAddress = IpAddress 
            };
    }
}
