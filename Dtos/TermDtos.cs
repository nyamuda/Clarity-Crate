using Clarity_Crate.Models;
using System.ComponentModel.DataAnnotations;

public class TermCreateDto
{

    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Definition { get; set; }


    [Required]
    public Subject? Subject { get; set; }

    [Required]
    public Topic? Topic { get; set; }

    [Required]
    public Curriculum? Curriculum { get; set; }

}


public class TermUpdateDto
{

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Definition { get; set; }

    [Required]
    public int TopicId { get; set; }

}