﻿namespace StarWarsApi.Model;

public class Affiliation
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<Character> Characters { get; set; }
}
