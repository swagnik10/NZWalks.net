using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilter;
using NZWalks.API.Data;
using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    // https://localhost:7090/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepositories iRegionRepository;
        private readonly IMapper mapper;

        //Constructor Dependency
        public RegionsController(NZWalksDbContext dbContext, IRegionRepositories iRegionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.iRegionRepository = iRegionRepository;
            this.mapper = mapper;
        }
        //Get all regions
        // GET: https://localhost:port_Number/api/regions
        //Route Attribute
        [HttpGet]
        public  async Task<IActionResult> GetAllRegion()
        {
            //HardCoded Data
            /*List<Regions> regionList = new List<Regions>
            {
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = ""
                },
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = ""
                },
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Canterbury.",
                    Code = "CAB",
                    RegionImageUrl = ""
                },
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Hawke's Bay",
                    Code = "HAB",
                    RegionImageUrl = ""
                },
            };*/

            //Getting data from Domain Model
            //List<Regions> regionList = dbContext.Regions.ToList();
            List<Regions> regionList = await iRegionRepository.GetAllRegionAsync();
            //converting domain model to DTO
            /*List<RegionsDTO> regionsDTOList = new List<RegionsDTO>();
            foreach (var region in regionList)
            {
                var regionDTO = new RegionsDTO
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                };
                regionsDTOList.Add(regionDTO);
            }*/

            //var regionsDTOList = mapper.Map<List<Regions>>(regionList);   
            //Returning the DTO 
            //Map domian model to dto
            return Ok(mapper.Map<List<RegionsDTO>>(regionList));
        }
        //Get Region By Id
        //GET: https://localhost:port_Number/api/regions/{id}
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            //Regions region = dbContext.Regions.SingleOrDefault(r => r.Id == id);
            //Find only use in case of primary key
            //var region = dbContext.Regions.Find(id);
            //Getting the requirement from domain model
            //Regions region = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            Regions? region = await iRegionRepository.GetRegionsByIDAsync(id);
            if (region == null)
            {
                return BadRequest();
            }
            //Converting to DTO
            /*RegionsDTO regionDTO = new RegionsDTO
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };*/
            //Returning DTO 
            //mapping domain model to dto
            return Ok(mapper.Map<RegionsDTO>(region));
        }

        //Post to Create New Region
        //Post: https://localhost:port_Number/api/Regions
        [HttpPost]
        //Custom Model validator
        [ValidateModel]
        public async Task<IActionResult> InsertRegion([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            //Converting DTO to Domain model
            /*Regions regionModel = new Regions
            {
                Name = addRegionRequestDTO.Name,
                Code = addRegionRequestDTO.Code,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl
            };*/
            //Mapping RequestDTO to Domain Model
            Regions regionModel = mapper.Map<Regions>(addRegionRequestDTO);

            //Inserting Domain model to database use Domain Model to create region
            /*dbContext.Regions.Add(regionModel);
            dbContext.SaveChanges();*/

            await iRegionRepository.InsertRegionsAsync(regionModel);

            //Map domain back to DTO
            /*RegionsDTO regionDTO = new RegionsDTO
            {
                Id = regionModel.Id,
                Name = regionModel.Name,
                Code = regionModel.Code,
                RegionImageUrl = regionModel.RegionImageUrl
            };*/
            //Mapping  domain model to DTO
            RegionsDTO regionDTO = mapper.Map<RegionsDTO>(regionModel);

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDTO.Id }, regionDTO);
        }


        //Update Region
        //Put: https://localhost:port_Number/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        //Custom Model Validator
        [ValidateModel]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid Id, [FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            //Searching the id in Domain Model
            //Regions updatedRegion = dbContext.Regions.FirstOrDefault(x => x.Id == Id);
           /* Regions region = new Regions
            {
                Name = addRegionRequestDTO.Name,
                Code = addRegionRequestDTO.Code,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl
            };*/
           //Mapping to requestDTO to Domain 
            Regions region = mapper.Map<Regions>(addRegionRequestDTO);
            Regions? updatedRegion = await iRegionRepository.UpdateRegionsAsync(Id,region);
            if (updatedRegion == null)
            {
                return NotFound(Id);
            }
            //Updating the Domain Model from DTO
            /*updatedRegion.Name = addRegionRequestDTO.Name;
            updatedRegion.Code = addRegionRequestDTO.Code;
            updatedRegion.RegionImageUrl = addRegionRequestDTO.RegionImageUrl;*/

            //SaveChanges to Database
            //dbContext.SaveChanges();
            
            //Converting to DTO 
           /* RegionsDTO regionsDTO = new RegionsDTO
            {
                Id = updatedRegion.Id,
                Name = updatedRegion.Name,
                Code = updatedRegion.Code,
                RegionImageUrl = updatedRegion.RegionImageUrl
            };*/
           //Mapping Domain to DTO
           RegionsDTO regionsDTO = mapper.Map<RegionsDTO>(region);
            return Ok(regionsDTO);

        }

        //Delete Region
        //Delete: https://localhost:Port_Number/api/Regions?id="wgewrhwgq"
        [HttpDelete]
        public async Task<IActionResult> DeleteRegion([FromQuery] Guid Id)
        {
            //Regions regions = dbContext.Regions.FirstOrDefault(x => x.Id == Id);
            Regions regions = await iRegionRepository.DeleteRegionsAsync(Id);
            if (regions == null)
            {
                return NotFound($"Not Found {Id}");
            }
            //Delete the region
            /*dbContext.Remove(regions);
            dbContext.SaveChanges();*/
            return Ok($"Sucessfully deleted {Id}");
        }


    }

}
