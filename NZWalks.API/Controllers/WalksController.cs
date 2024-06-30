using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepositories walkRepo;
        private readonly IMapper mapper;

        public WalksController(IWalkRepositories walkRepo, IMapper mapper)
        {
            this.walkRepo = walkRepo;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] AddWalkRequestDTO walkRequestDTO)
        {
            Walks walkDomain = mapper.Map<Walks>(walkRequestDTO);

            Walks returnedWalk = await walkRepo.InsertAsync(walkDomain);


            return Ok(mapper.Map<WalksDTO>(returnedWalk));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            List<Walks> walksList = await walkRepo.GetAllAsync();
            return Ok(mapper.Map<List<WalksDTO>>(walksList));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdWalk([FromRoute] Guid id)
        {
            Walks? walk = await walkRepo.GetByIdAsync(id);
            if (walk == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalksDTO>(walk));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] AddWalkRequestDTO walkRequestDTO)
        {
            Walks walk = mapper.Map<Walks>(walkRequestDTO);
            Walks? reWalk = await walkRepo.UpdateAsync(id,walk);
            if(reWalk == null)
                return NotFound();
            return Ok(mapper.Map<WalksDTO>(reWalk));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteWalk([FromQuery] Guid id)
        {
            bool status = await walkRepo.DeleteAsync(id);
            if(status == false)
                return NotFound();
            return Ok($"Successfully deleted {id}");
        }
    }
}
