namespace BreckProject1.Models
{
    public class Trails
    {
        public int TrailNumber { get; set; }
        public string TrailName { get; set; }
        public string GetTo { get; set; }
        public string GondolaDirection { get; set; }
        public string ParkingDirection { get; set; }
        public bool IsOpened { get; set; }
        public int Peak { get; set; }
    }
}
