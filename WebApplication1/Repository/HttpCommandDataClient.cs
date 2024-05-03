using System.Text;
using System.Text.Json;
using WebApplication1.DTO;
using WebApplication1.Irepository;

namespace WebApplication1.Repository
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private HttpClient _httpClient;
        private IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

        }
        public async Task SendPlatformToCommand(PlatformReadDTO plat)
        {
            var sendable = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json"
                );
            var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}", sendable);

            if (response.IsSuccessStatusCode) Console.WriteLine("Post request was done perfectly");
            else Console.WriteLine("Post Request failed");
        }
    }
}
