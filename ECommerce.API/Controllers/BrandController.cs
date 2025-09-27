using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    public class BrandController : BaseApiController
    {
        private readonly IGenericRepositories<Brand> _brandRepo;
        public BrandController(IGenericRepositories<Brand> brandRepo)
        {
            _brandRepo = brandRepo;

        }

        [HttpGet("{Id}")]

        public async Task<ActionResult<Brand>> GetBrandById(int Id)
        {
            var brand = _brandRepo.GetAsync(Id);
            return Ok(await brand);
        }

        [HttpGet]
        public async Task<ActionResult<Brand>> GetAll()
        {
            var brands = _brandRepo.GetAllAsync();
            return Ok(await brands);

        }
    }
}
