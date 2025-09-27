using AutoMapper;
using ECommerce.API.Dtos;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    public class TypeController : BaseApiController
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public TypeController(IUnitofWork unitofWork, IMapper mapper)
        {
           
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        [HttpGet("{Id}")]

        public async Task<ActionResult<TypeToReturnDto>> GetTypeById(int Id)
        {
            var typeRepo = _unitofWork.Repository<ProductType>();
            var type = typeRepo.GetAsync(Id);
            return Ok(_mapper.Map<ProductType,TypeToReturnDto>(await type));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeToReturnDto>>> GetAll()
        {
            var typesRepo = _unitofWork.Repository<ProductType>();
            var types = typesRepo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeToReturnDto>>(await types));

        }
    }
}
