using System.ComponentModel.DataAnnotations;

namespace Product.API.Entities
{
    public class Category
    {
        [Key]
        public int iCategory { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
    }
}
