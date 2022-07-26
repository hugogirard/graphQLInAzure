namespace StarWarsApi.Model;

public class Ship
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<Character> Characters { get; set; }
}
