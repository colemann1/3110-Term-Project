namespace _3110_Term_Project.Models.ViewModels
{
    public class EventDetailsVM
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string? Description { get; set; }
        public int Capacity { get; set; }
        public string VenueName { get; set; } // Display venue name instead of Id?
    }
}
