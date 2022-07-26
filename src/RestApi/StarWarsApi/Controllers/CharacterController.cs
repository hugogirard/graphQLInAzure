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
    }
}
