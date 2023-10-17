using System.ComponentModel.DataAnnotations;

namespace HandySquad.dto;

public class RatingRequestDto
{
    [Required]
    public double Rating { get; set; }
}