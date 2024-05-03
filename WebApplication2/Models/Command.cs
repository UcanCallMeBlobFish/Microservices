using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Command
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string CommandLine { get; set; }

        public int PlatformId { get; set; }

        public Platform Platform { get; set; }
    }
}
