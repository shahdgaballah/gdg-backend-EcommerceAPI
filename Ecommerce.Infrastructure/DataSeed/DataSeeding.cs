using ECommerce.Domain.Entities;
using System.Text.Json;

namespace Ecommerce.Infrastructure.DataSeed
{
    public class DataSeeding
    {
        public static void AddData(ECommerceContext _eCommerceContext) {
            if (_eCommerceContext.Brands.Count() == 0)
            {
                var brands = File.ReadAllText("../Ecommerce.Infrastructure/DataJson/brands.json");

                var brandsresult = JsonSerializer.Deserialize<List<Brand>>(brands);

                if(brandsresult?.Count > 0)
                {
                    foreach (var brand in brandsresult)
                    {
                        
                        _eCommerceContext.Brands.Add(brand);
                    }
                    _eCommerceContext.SaveChanges();

                }
                
            }

            if (_eCommerceContext.Types.Count() == 0)
            {
                var types = File.ReadAllText("../Ecommerce.Infrastructure/DataJson/types.json");

                var typesresult = JsonSerializer.Deserialize<List<ProductType>>(types);

                if (typesresult?.Count > 0)
                {
                    foreach (var type in typesresult)
                    {
                        
                        _eCommerceContext.Types.Add(type);
                    }
                    _eCommerceContext.SaveChanges();

                }
            }
            if (_eCommerceContext.Products.Count() == 0)
            {
                var products = File.ReadAllText("../Ecommerce.Infrastructure/DataJson/products.json");

                var productsresult = JsonSerializer.Deserialize<List<Product>>(products);

                if (productsresult?.Count > 0)
                {
                    foreach (var product in productsresult)
                    {
         
                        _eCommerceContext.Products.Add(product);
                    }
                    _eCommerceContext.SaveChanges();

                }
            }


        }
        


    }

}
    

