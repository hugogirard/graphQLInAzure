using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StarWarsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private readonly StarWarsContext _repository;

        public CharacterController(StarWarsContext context)
        {
            _repository = context;
        }

        [HttpGet(Name = "GetAllCharacters")]
        public async Task<IEnumerable<CharacterDto>> Get()
        {
            return await _repository.Characters     
                                    .Select(c => new CharacterDto 
                                    { 
                                        Id = c.Id,
                                        Name = c.Name,
                                        Affiliation = c.Affiliation.Name,
                                        ShipName =  c.Ship == null ? string.Empty : c.Ship.Name,
                                        PlanetName = c.Planet.Name
                                    })
                                    .ToListAsync();
        }

        [HttpGet("{id}", Name = "GetCharacterById")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _repository.Characters
                                          .Include(c => c.Affiliation)
                                          .Include(c => c.Planet)
                                          .Include(c => c.Ship)
                                          .SingleOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                return new NotFoundObjectResult($"Cannot find character with id {id}");

            return new OkObjectResult(new CharacterDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Affiliation = entity.Affiliation.Name,
                ShipName = entity.Ship == null ? string.Empty : entity.Ship.Name,
                PlanetName = entity.Planet.Name
            });

        }
    }
}
