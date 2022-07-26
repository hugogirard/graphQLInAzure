namespace StarWarsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlanetController
{
    private readonly StarWarsContext _repository;

    public PlanetController(StarWarsContext context)
    {
        _repository = context;
    }

    [HttpGet(Name = "GetAllPlanet")]
    public async Task<IEnumerable<BaseEntityDto>> Get()
    {
        return await _repository.Planets
                                .Select(p => new BaseEntityDto
                                {
                                    Id = p.Id,
                                    Name = p.Name
                                })
                                .ToListAsync();
    }
}
