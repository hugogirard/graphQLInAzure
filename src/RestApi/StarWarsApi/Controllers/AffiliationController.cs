

namespace StarWarsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AffiliationController
{
    private readonly StarWarsContext _repository;

    public AffiliationController(StarWarsContext context)
    {
        _repository = context;
    }

    [HttpGet(Name = "GetAllAffiliation")]
    public async Task<IEnumerable<BaseEntityDto>> Get()
    {
        return await _repository.Affiliations
                                .Select(a => new BaseEntityDto
                                {
                                    Id = a.Id,
                                    Name = a.Name
                                })
                                .ToListAsync();
    }
}
