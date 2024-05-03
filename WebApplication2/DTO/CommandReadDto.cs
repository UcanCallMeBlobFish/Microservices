using WebApplication2.Models;

namespace WebApplication2.DTO
{
    public class CommandReadDto
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string CommandLine { get; set; }
        public int PlatformId { get; set; }

    }
}
