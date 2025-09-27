using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!; //null! forget operator to avoid nullable warning
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType Type { get; set; } = null!;

        public int ProductBrandId { get; set; }
        public Brand Brand { get; set; }


    }
}
