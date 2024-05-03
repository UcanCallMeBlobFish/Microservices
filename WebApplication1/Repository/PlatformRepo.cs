using WebApplication1.Data;
using WebApplication1.Irepository;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class PlatformRepo : IPlatformRepo
    {
        private AppDbContext _context;
        public PlatformRepo(AppDbContext context)
        {
            _context = context;
            
        }
        public void CreatePlatform(Platform platform)
        {
            if(platform is not null) _context.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            Platform item = _context.Platforms.FirstOrDefault(p => p.Id == id);
            return item;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
