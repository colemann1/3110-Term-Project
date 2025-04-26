namespace _3110_Term_Project.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        public List<Registration> Registrations { get; set; }
    }
}
