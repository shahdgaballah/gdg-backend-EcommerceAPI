using AutoMapper;
using ECommerce.API.Dtos;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    public class BrandController : BaseApiController
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public BrandController(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }


        [HttpGet("{Id}")]

        public async Task<ActionResult<BrandToReturnDto>> GetBrandById(int Id)
        {
            var brandRepo = _unitofWork.Repository<Brand>();

            var brand = brandRepo.GetAsync(Id);

            return Ok(_mapper.Map<Brand, BrandToReturnDto>(await brand));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandToReturnDto>>> GetAll()
        {
            var brandRepo = _unitofWork.Repository<Brand>();
            var brands = brandRepo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<Brand>, IEnumerable<BrandToReturnDto>>(await brands));

        }
    }
}
