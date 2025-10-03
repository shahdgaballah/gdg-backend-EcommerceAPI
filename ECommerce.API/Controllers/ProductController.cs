using AutoMapper;
using Ecommerce.Infrastructure.Repositories;
using ECommerce.API.Dtos;
using ECommerce.API.Filters;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ECommerce.API.Controllers
{

    [ServiceFilter(typeof(AsyncValidationFilter))] //apply filter at product controller endpoints
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

        [HttpPost]
        public async Task<ActionResult<ProductToCreateDto>> CreateProduct(ProductToCreateDto productToCreate)
        {
            try
            {
                var productRepo = _unitofWork.Repository<Product>();

                var product = _mapper.Map<ProductToCreateDto, Product>(productToCreate);

                productRepo.Add(product);

                var result = await _unitofWork.CompleteAsync();

                if (result <= 0) return BadRequest("Failed to create product");

                var productToReturn = _mapper.Map<Product, ProductToReturnDto>(product);

                return CreatedAtAction(nameof(GetProductById), new { Id = product.Id }, productToReturn);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet ("Filtered")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts( [FromQuery] ProductQueryParameters queryParameters)
        {
            var productsRepo = _unitofWork.Repository<Product>();

            var products = await productsRepo.GetAllAsync();

            //search
            if (!string.IsNullOrEmpty(queryParameters.Search))
            {
                products = products.Where(p => p.Name.Contains(queryParameters.Search));
            }

            //sorting
            products = queryParameters.Sort switch
            {
                "price" => products.OrderBy(p => p.Price),
                "priceDesc" => products.OrderByDescending(p => p.Price),
                "name" => products.OrderBy(p => p.Name),
                "nameDesc" => products.OrderByDescending(p => p.Name)
            };

            //pagination
            int pageNumber = queryParameters.PageNumber ?? 1;
            int pageSize = queryParameters.PageSize ?? 10;
            products = products.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));


        }
    }
}
