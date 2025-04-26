using System.Data;

namespace _3110_Term_Project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<Role> Roles { get; set; }
        public List<Registration> Registrations { get; set; }
    }

}
