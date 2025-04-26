namespace _3110_Term_Project.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string RegistrationStatus { get; set; }
    }

}
