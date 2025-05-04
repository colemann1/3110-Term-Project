namespace _3110_Term_Project.Models.ViewModels
{
    public class PersonDetailsVM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } // Display roles (enums)as list of strings
    }
}
