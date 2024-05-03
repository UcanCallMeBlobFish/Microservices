using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.DTO
{
    public class CommandCreateDto
    {
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
    }
}
