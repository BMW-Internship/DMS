namespace DMS_Internship.Backend.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }

        public string Series { get; set; } = "";

        public float PriceInclusive { get; set; }

        public float Price { get; set; }
    }
}