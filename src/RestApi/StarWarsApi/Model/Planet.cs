using System.ComponentModel.DataAnnotations;

namespace StarWarsApi.Model;

public class Planet
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<Character> Characters { get; set; }
}
