using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : Controller
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        //CREATE Walk
        //POST: api/walks
        [HttpPost]
        [ValidateModel]  //Added CustomActionFilter
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map DTO to Domain model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            //Map DomainModel to Dto

            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        //GetWalks
        //GET: /api/walks/filterOn=Name
        [HttpGet]
        public async Task<IActionResult> GetAllFilter([FromQuery] string? filterOn, [FromQuery] string? filterQuery)
        {
            var walksDomainModel = await walkRepository.GetAllFilter(filterOn, filterQuery);
            return Ok(mapper.Map<List<WalkDTO>>(walksDomainModel));
        }

        //GET Walks
        //GET: /api/walks
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var walksDomainModel = await walkRepository.GetAllAsync();

        //    //Map Domain to Dto
        //    return Ok(mapper.Map<List<WalkDTO>>(walksDomainModel));
        //}

        //GET walk by Id
        //GET: /api/Walks{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if(walkDomainModel == null)
            {
                return NotFound();
            }
            //Map Domain to Dto
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        //Update walk by id
        //PUT: /api/walks{id}
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel] //Added CustomActionFilter
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatewalkRequestDto updatewalkRequestDto)
        {
            //Map DTO to Domain
            var walkDomainmodel = mapper.Map<Walk>(updatewalkRequestDto);

            walkDomainmodel = await walkRepository.UpdateAsync(id, walkDomainmodel);
            if (walkDomainmodel == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<WalkDTO>(walkDomainmodel));
        }

        //Delete walk by id
        //DELETE: /api/walks{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleteWalkDomain = await walkRepository.DeleteAsync(id);
            if (deleteWalkDomain == null)
            {
                return NotFound();
            }
            //Map Domain to DTO
            return Ok(mapper.Map<WalkDTO>(deleteWalkDomain));
        }
    }
}
