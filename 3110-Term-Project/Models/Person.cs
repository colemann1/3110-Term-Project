using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace _3110_Term_Project.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Personname { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public List<Registration> Registrations { get; set; }
        public ICollection<Event> Events { get; set; }
    }

}
