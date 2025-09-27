using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    public class TypeController : BaseApiController
    {
        private readonly IGenericRepositories<ProductType> _typeRepo;
        public TypeController(IGenericRepositories<ProductType> typeRepo)
        {
            _typeRepo = typeRepo;

        }

        [HttpGet("{Id}")]

        public async Task<ActionResult<ProductType>> GetTypeById(int Id)
        {
            var type = _typeRepo.GetAsync(Id);
            return Ok(await type);
        }

        [HttpGet]
        public async Task<ActionResult<ProductType>> GetAll()
        {
            var types = _typeRepo.GetAllAsync();
            return Ok(await types);

        }
    }
}
