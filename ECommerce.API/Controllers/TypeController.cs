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

        public ActionResult<ProductType> GetTypeById(int Id)
        {
            var type = _typeRepo.Get(Id);
            return Ok(type);
        }

        [HttpGet]
        public ActionResult<ProductType> GetAll()
        {
            var types = _typeRepo.GetAll();
            return Ok(types);

        }
    }
}
