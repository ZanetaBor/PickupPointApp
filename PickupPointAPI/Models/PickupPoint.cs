namespace PickupPointAPI.Models
{
    public class PickupPoint
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Address { get; set; } 
        public string OpeningHours { get; set; }
        public string ContactNumber { get; set; }
    }
}
