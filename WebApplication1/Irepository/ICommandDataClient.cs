using WebApplication1.DTO;

namespace WebApplication1.Irepository
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDTO plat);
    }
}
