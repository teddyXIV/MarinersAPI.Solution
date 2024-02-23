using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MarinersApi.Models;

public class Player
{
    public int PlayerId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(0, 99, ErrorMessage = "Must be between 0 and 99")]
    public int Number { get; set; }
    [Required]
    [Range(0, 1, ErrorMessage = "Must be between 0 and 1")]
    public double Average { get; set; }
    [Required]
    [Range(0, 1, ErrorMessage = "Must be between 0 and 1")]
    public double OnBase { get; set; }
    [Required]
    [Range(0, 4, ErrorMessage = "Must be between 0 and 4")]
    public double Slug { get; set; }
    public double Ops { get; private set; }
    [Required]
    public int Homerun { get; set; }
    public string CreatorId { get; set; }
    public virtual IdentityUser Creator { get; set; }

    public Player(double onBase, double slug)
    {
        OnBase = onBase;
        Slug = slug;
        Ops = OnBase + Slug;
    }
}