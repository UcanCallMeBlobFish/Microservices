using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ExternalID { get; set; }

        public string Name { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();

    }
}
