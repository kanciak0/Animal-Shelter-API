using Project_API.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_API.Entities
{
    public class Animal_entity
    {
        [Key]
        public Guid Animal_UUID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public virtual User_entity? User { get; set; }
    }
}
