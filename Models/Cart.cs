using System.ComponentModel.DataAnnotations;

namespace Mycloth_website.Models
{
    public class Cart
    {
        [Key]

        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public string? ProductDescription { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        public decimal DicountProductPrice { get; set; }
    }
}
