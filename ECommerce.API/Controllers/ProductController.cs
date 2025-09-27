using Ecommerce.Infrastructure.Repositories;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepositories<Product> _productRepo;
        public ProductController(IGenericRepositories<Product> productRepo)
        {
            _productRepo = productRepo;

        }

        [HttpGet("{Id}")]

        public ActionResult<Product> GetProductById(int Id)
        {
            var product = _productRepo.Get(Id);
            return Ok(product);
        }

        [HttpGet]
        public ActionResult<Product> GetAll()
        {
            var products = _productRepo.GetAll();
            return Ok(products);

        }
    }
}
