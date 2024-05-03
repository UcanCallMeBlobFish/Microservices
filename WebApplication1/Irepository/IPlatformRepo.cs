using WebApplication1.Models;

namespace WebApplication1.Irepository
{
    public interface IPlatformRepo
    {
        void SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();

        Platform GetPlatformById(int id);

        void CreatePlatform(Platform platform);


    }
}
