using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        public readonly NZWalksDBContext dbContext;

        public readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDBContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }


        /*  GetAll() - Before Repositary Usage and AutoMapper  
         * [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get data from DataBase - Domain Models
            var regionDomain = await dbContext.Regions.ToListAsync();


             //Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach(var region in regionDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl,
                });
            }

            //Return DTOs back to client
            return Ok(regionsDto);
        }

         */
        //GET ALL REGIONS
        //GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get data from DataBase - Domain Models
            var regionDomain = await regionRepository.GetAllAsync();        // Using Repositary

            //Return DTOs back to client                                    // Auto Mapper
            return Ok(mapper.Map<List<RegionDto>>(regionDomain));           // var regionsDto = mapper.Map<List<RegionDto>>(regionDomain);
        }

        /* GetById(Guid id) - Before Repositary Usage and AutoMapper
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            //var region = dbContext.Regions.Find(id); - works

            //Using LinQ method
            //var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id); 

            var regionDomain = await regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            // Map Domain Models to DTOs
            var regionsDto = new RegionDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            //Return DTOs back to client
            return Ok(regionsDto);
        }*/

        //Get Region By ID
        //GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id); // Using Repositary
            if (regionDomain == null)
            {
                return NotFound();
            }
            //Return DTOs back to client
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        /*  Create([FromBody] AddReqionRequestDto addReqionRequestDto) - Before Repositary Usage and AutoMapper
         [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddReqionRequestDto addReqionRequestDto)
        {
            //Map or Convert DTO to Domain Model
            var regionDomainModel = new Region
            {
                Code = addReqionRequestDto.Code,
                Name = addReqionRequestDto.Name,
                RegionImageUrl = addReqionRequestDto.RegionImageUrl
            };

            //Use Domain to Create region
            //await dbContext.Regions.AddAsync(regionDomainModel);
            //await dbContext.SaveChangesAsync();

            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
            //Map Domain back to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }*/
        //POST to Create new Region
        //POST: https://localhost:portnumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddReqionRequestDto addReqionRequestDto)
        {
            if (ModelState.IsValid)
            {
                var regionDomainModel = mapper.Map<Region>(addReqionRequestDto); // Using AutoMapper

                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                var regionDto = mapper.Map<RegionDto>(regionDomainModel); // Using AutoMapper

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        //Update Region
        /* Update : Before Repositary Usage and AutoMapper
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateReqionRequestDto updateReqionRequestDto)
        {
            //Map DTO to Domain
            var regionDomain = new Region
            {
                Code = updateReqionRequestDto.Code,
                Name = updateReqionRequestDto.Code,
                RegionImageUrl = updateReqionRequestDto.RegionImageUrl
            };
            //var regionDomaimModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id); -- taken care in RegionRepository class
            var regionDomaimModel = await regionRepository.UpdateAsync(id, regionDomain);
            
            if (regionDomaimModel == null)
            {
                return NotFound();
            }
            //regionDomaimModel.Code = updateReqionRequestDto.Code;  -- taken care in RegionRepository class
            //regionDomaimModel.Name = updateReqionRequestDto.Name;
            //regionDomaimModel.RegionImageUrl = updateReqionRequestDto.RegionImageUrl;

            //await dbContext.SaveChangesAsync();

            //Convert Domain to DTO         //Use AutoMapper
            var regionDto = new RegionDto
            {
                Id = regionDomaimModel.Id,
                Name = regionDomaimModel.Name,
                Code = regionDomaimModel.Code,
                RegionImageUrl = regionDomaimModel.RegionImageUrl
            };

            return Ok(regionDto);
        }

         */

        //PUT :  https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")] // :Guid is added to make it as typeSafe
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateReqionRequestDto updateReqionRequestDto)
        {
            if (ModelState.IsValid)
            {
                //Map DTO to Domain Using AutoMapper
                var regionDomain = mapper.Map<Region>(updateReqionRequestDto);

                var regionDomaimModel = await regionRepository.UpdateAsync(id, regionDomain); // Calling Repositary
                if (regionDomaimModel == null)
                {
                    return NotFound();
                }
                //Convert Domain to DTO   Using AutoMapper
                var regionDto = mapper.Map<RegionDto>(regionDomaimModel);
                return Ok(regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //Delete Region
        /* Delete - Before Repositary Usage and AutoMapper
         public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomaimModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id); -- taken care in RegionRepository class

            if (regionDomaimModel == null)
            {
                return NotFound();
            }
            //Delete region
            dbContext.Regions.Remove(regionDomaimModel); 
            await dbContext.SaveChangesAsync();
            //return Ok(); // else

            //return deleted region back
            //Convert Domain to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomaimModel.Id,
                Name = regionDomaimModel.Name,
                Code = regionDomaimModel.Code,
                RegionImageUrl = regionDomaimModel.RegionImageUrl
            };
            return Ok(regionDto);
        }*/
        //DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomaimModel = await regionRepository.DeleteAsync(id);
            if (regionDomaimModel == null)
            {
                return NotFound();
            }
            var regionDto = mapper.Map<RegionDto>(regionDomaimModel); //Convert Domain to DTO using AutpMapper
            return Ok(regionDto);
        }
    }
}
