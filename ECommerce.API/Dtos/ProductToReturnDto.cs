using ECommerce.Domain.Entities;

namespace ECommerce.API.Dtos
{
    public class ProductToReturnDto
    {
        public string Name { get; set; } = null!; //null! forget operator to avoid nullable warning
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
        public int ProductTypeId { get; set; }
        public string Type { get; set; } = null!;
        public int ProductBrandId { get; set; }
        public string Brand { get; set; }
    }
}
