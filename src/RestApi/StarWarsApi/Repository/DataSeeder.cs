namespace StarWarsApi.Repository;

public class DataSeeder
{
    private readonly StarWarsContext _context;

    public DataSeeder(StarWarsContext dbContext)
    {
        _context = dbContext;
    }

    public void Seed() 
    {
        _context.Database.EnsureCreated();
        CreatePlanet();
        CreateAffiliation();
    }

    private void CreatePlanet() 
    {
        var planets = new List<Planet>()
        {
            new Planet()
            { 
                Name = "Tatooine"
            },
            new Planet()
            {
                Name = "Korriban"
            },
            new Planet()
            {
                Name = "Alderan"
            },
            new Planet()
            {
                Name = "Naboo"
            },
            new Planet()
            {
                Name = "Corellia"
            },
            new Planet()
            {
                Name = "Kashyyyk"
            }
        };

        _context.Planets.AddRange(planets);
        _context.SaveChanges();
    }

    private void CreateAffiliation() 
    {
        var affiliations = new List<Affiliation>()
        {
            new Affiliation()
            { 
                Name = "Sith"
            },
            new Affiliation()
            {
                Name = "Jedi"
            },
            new Affiliation()
            {
                Name = "Smuggler"
            },
            new Affiliation()
            {
                Name = "Republic"
            },
            new Affiliation()
            {
                Name = "Rebel"
            },
            new Affiliation()
            {
                Name = "Empire"
            }
        };

        _context.Affiliations.AddRange(affiliations);
        _context.SaveChanges();
    }
}
