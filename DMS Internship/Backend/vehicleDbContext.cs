using System.ComponentModel.DataAnnotations;

namespace DMS_Internship.Backend
{
    public class vehicleDbContext
    {

        [Required]
        public int vehicleID { get; set; }

        [Required, MaxLength(255)]
        public string make { get; set; } = "";

        [Required, MaxLength(255)]
        public string? Model { get; set; } = "";

        [Required]
        public float price { get; set; }
    }
}

