using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.AsyncDataServices;
using WebApplication1.DTO;
using WebApplication1.Irepository;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;
        private readonly IMessageBusClient _messageBusClient;

        public PlatformController(IPlatformRepo repo, IMapper mapper, ICommandDataClient commandDataClient, IMessageBusClient messageBusClient)
        {
            _repo = repo;
            _mapper = mapper; 
            _commandDataClient = commandDataClient;
            _messageBusClient = messageBusClient;
        }

        [HttpGet("GetPlatforms")]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetAllPlatforms()
        {
            IEnumerable<Platform> platforms = _repo.GetAllPlatforms();
            var platformDtos = _mapper.Map<IEnumerable<PlatformReadDTO>>(platforms);
            return Ok(platformDtos);
        }

        [HttpGet("GetPlatformById/{id}")]
        public ActionResult<PlatformReadDTO> GetPlatform(int id)
        {
            PlatformReadDTO item = _mapper.Map<PlatformReadDTO>(_repo.GetPlatformById(id));
            if (item == null) return NotFound();
            return Ok(item);

        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDTO>> AddPlatform([FromBody] PlatformCreateDTO platform)
        {
            if(platform is null) return BadRequest();

            _repo.CreatePlatform(_mapper.Map<Platform>(platform));
            _repo.SaveChanges();

            var plt = _mapper.Map<Platform>(platform);
            var ReadDto = _mapper.Map<PlatformReadDTO>(plt);


            //Send sync message using http.
            try
            {
                await _commandDataClient.SendPlatformToCommand(ReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> couldnot send syncronously");
            }
            //Send async message using rabbitMQ

            try
            {
                var platformPublishedDto = _mapper.Map<PlatformPublishDTO>(ReadDto);
                platformPublishedDto.Event = "Platform_Published";
                _messageBusClient.PublishNewPlatform(platformPublishedDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
            }
            return Ok(platform);

        }

       
        
    }
}
