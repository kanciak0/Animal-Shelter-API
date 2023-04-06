using Project_API.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_API.Entities
{
    public class Animal
    {
        [Key]
        public Guid Animal_UUID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public virtual User? User { get; set; }
    }
}
