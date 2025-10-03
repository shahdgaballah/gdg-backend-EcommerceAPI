using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Dtos
{
    public class ProductToCreateDto
    {
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public int TypeId { get; set; }
        public int BrandId { get; set; }
    }
}
