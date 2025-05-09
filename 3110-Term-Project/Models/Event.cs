﻿using System.ComponentModel.DataAnnotations;
using _3110_Term_Project.Models.ViewModels;

namespace _3110_Term_Project.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [StringLength(256)]
        public string EventName { get; set; } = String.Empty;
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string? Description { get; set; }
        public int Capacity { get; set; }
        public List<Registration>? Registrations { get; set; }
        public ICollection<Person>? Persons { get; set; }
    }
}
