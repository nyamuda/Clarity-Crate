using Clarity_Crate.Models;
using System.ComponentModel.DataAnnotations;

public class TopicCreateDto
{

    [Required]
    public string? Name { get; set; }

    [Required]
    public List<Subject>? Subjects { get; set; }

}