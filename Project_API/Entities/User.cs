﻿using Project_API.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_API.Entities
{
    public class User
    {
        [Key]
        public Guid UUID { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}
