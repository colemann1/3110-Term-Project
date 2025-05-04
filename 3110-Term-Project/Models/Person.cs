using System.Data;
using Microsoft.AspNetCore.Identity;

namespace _3110_Term_Project.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public List<Role> Roles { get; set; }
        public List<Registration> Registrations { get; set; }
    }

}
