using Microsoft.EntityFrameworkCore;

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
        CreateShip();
        CreateCharacter();

    }

    private void CreateCharacter() 
    {
        var planets = _context.Planets.ToList();
        var ships = _context.Ships.ToList();
        var affiliations = _context.Affiliations.ToList();

        var tatooine = planets.Single(x => x.Name == "Tatooine");
        var korriban = planets.Single(x => x.Name == "Korriban");
        var alderan = planets.Single(x => x.Name == "Alderan");
        var naboo = planets.Single(x => x.Name == "Naboo");
        var corellia = planets.Single(x => x.Name == "Corellia");
        var kashyyyk = planets.Single(x => x.Name == "Kashyyyk");


        var jedi = affiliations.Single(x => x.Name == "Jedi");
        var sith = affiliations.Single(x => x.Name == "Sith");
        var rebel = affiliations.Single(x => x.Name == "Rebel");
        var smuggler = affiliations.Single(x => x.Name == "Smuggler");

        var republic = affiliations.Single(x => x.Name == "Republic");

        var characters = new List<Character> 
        { 
            new Character 
            { 
               Name = "Luke Skywalker",
               Planet = tatooine,
               Affiliation = jedi,
               Ship = _context.Ships.Single(x => x.Name == "Red 5")
            },
            new Character
            {
               Name = "Anakin Skywalker",
               Planet = tatooine,
               Affiliation = jedi
            },
            new Character
            {
               Name = "Darth Vader",
               Planet = tatooine,
               Affiliation = sith,
               Ship = _context.Ships.Single(x => x.Name == "Darth Vader's TIE Advanced")
            },
            new Character
            {
               Name = "Naga Shadow",
               Planet = korriban,
               Affiliation = sith
            },
            new Character
            {
               Name = "Marka Ragnos",
               Planet = korriban,
               Affiliation = sith
            },
            new Character
            {
               Name = "Ajunta Pall",
               Planet = korriban,
               Affiliation = sith
            },
            new Character
            {
               Name = "Leia Organa",
               Planet = alderan,
               Affiliation = rebel
            },
            new Character
            {
               Name = "Bail Organa",
               Planet = alderan,
               Affiliation = rebel
            },
            new Character
            {
               Name = "Palpatine",
               Planet = naboo,
               Affiliation = sith
            },
            new Character
            {
               Name = "Padme Amidala",
               Planet = naboo,
               Affiliation = republic
            },
            new Character
            {
               Name = "Han Solo",
               Planet = corellia,
               Affiliation = smuggler,
               Ship = _context.Ships.Single(x => x.Name == "Millennium Falcon")
            },
            new Character
            {
               Name = "Chewbacca",
               Planet = kashyyyk,               
               Affiliation = smuggler,
               Ship = _context.Ships.Single(x => x.Name == "Millennium Falcon")
            }
        };

        _context.Characters.AddRange(characters);
        _context.SaveChanges();
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
            }
        };

        _context.Affiliations.AddRange(affiliations);
        _context.SaveChanges();
    }

    public void CreateShip() 
    {
        var ships = new List<Ship>() 
        { 
            new Ship 
            { 
                Name = "Millennium Falcon"
            },
            new Ship 
            {
                Name = "Red 5"
            },
            new Ship 
            {
                Name = "Darth Vader's TIE Advanced"
            }
        };

        _context.Ships.AddRange(ships);
        _context.SaveChanges();
    }
}
