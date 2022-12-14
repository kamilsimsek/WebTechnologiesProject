using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTechnologiesProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bir deger giriniz")]
        public string Name { get; set; }
        [Required, MinLength(4,ErrorMessage = "En az 2 karakter uzunlugunda olmalidir")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string Image { get; set; }

    }
}
