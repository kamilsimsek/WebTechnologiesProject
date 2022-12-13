using System.ComponentModel.DataAnnotations;

namespace WebTechnologiesProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
