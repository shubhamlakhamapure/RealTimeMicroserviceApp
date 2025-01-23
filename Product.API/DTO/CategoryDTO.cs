 using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.UI.DTO
{
    public class CategoryDTO
    {
        public int iCategory { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
    }
}
