using AutoMapper;
using Ecommerce.Infrastructure.Repositories;
using ECommerce.API.Dtos;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        [HttpGet("{Id}")]

        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int Id)
        {
            var productRepo = _unitofWork.Repository<Product>();

            var product = productRepo.GetAsync(Id);

            return Ok(_mapper.Map<Product, ProductToReturnDto>(await product));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetAll()
        {
            var productsRepo = _unitofWork.Repository<Product>();

            var products = productsRepo.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(await products));

        }
    }
}
