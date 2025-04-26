namespace _3110_Term_Project.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public List<Event> Events { get; set; }
    }
}
