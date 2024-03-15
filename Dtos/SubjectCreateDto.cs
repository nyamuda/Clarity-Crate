using Clarity_Crate.Models;
using System.ComponentModel.DataAnnotations;

namespace Clarity_Crate.Dtos
{
    public class SubjectCreateDto
    {


        [Required]
        public string? Name { get; set; }

        [Required]
        public Curriculum? Curriculum { get; set; }
    }
}
