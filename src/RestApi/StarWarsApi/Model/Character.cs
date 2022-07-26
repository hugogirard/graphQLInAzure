namespace StarWarsApi.Model;

public class Character
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    public int PlanetId { get; set; }

    public Planet Planet { get; set; }

    public short AffiliationId { get; set; }

    public Affiliation Affiliation { get; set; }

    public int? ShipId { get; set; }

    public Ship Ship { get; set; }
}
