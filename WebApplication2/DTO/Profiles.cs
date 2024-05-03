using AutoMapper;
using WebApplication2.Models;

namespace WebApplication2.DTO
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Command, CommandReadDto>();
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<CommandCreateDto, Command>();

            CreateMap<PlatformPublishedDTO, Platform>()
            .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.Id));


        }
    }
}
