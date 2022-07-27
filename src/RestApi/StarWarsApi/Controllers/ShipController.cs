namespace StarWarsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipController
{
    private readonly StarWarsContext _repository;

    public ShipController(StarWarsContext context)
    {
        _repository = context;
    }

    [HttpGet(Name = "GetAllShips")]
    public async Task<IEnumerable<BaseEntityDto>> Get()
    {
        return await _repository.Ships
                                .Select(s => new BaseEntityDto
                                {
                                    Id = s.Id,
                                    Name = s.Name
                                })
                                .ToListAsync();
    }
}
