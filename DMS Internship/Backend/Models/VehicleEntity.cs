using System.ComponentModel.DataAnnotations;

namespace DMS_Internship.Backend.Models
{
    public class VehicleEntity
    {

        [Required]
        public int VehicleId { get; set; }

        [Required, MaxLength(255)]
        public string Make { get; set; } = "";

        [Required, MaxLength(255)]
        public string? Model { get; set; } = "";

        [Required]
        public float Price { get; set; }
    }
}

