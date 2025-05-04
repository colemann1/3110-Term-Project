using System.Data;

namespace _3110_Term_Project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public List<Role> Roles { get; set; }
        public List<Registration> Registrations { get; set; }
    }

}
