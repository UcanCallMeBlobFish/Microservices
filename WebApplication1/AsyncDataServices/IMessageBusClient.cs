using WebApplication1.DTO;

namespace WebApplication1.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewPlatform(PlatformPublishDTO pulatformPublishedDTO);

    }
}
