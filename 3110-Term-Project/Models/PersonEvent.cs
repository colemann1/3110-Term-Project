namespace _3110_Term_Project.Models
{
    public class PersonEvent
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
