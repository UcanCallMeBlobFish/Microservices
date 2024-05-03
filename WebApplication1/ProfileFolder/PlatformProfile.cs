using AutoMapper;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.ProfileFolder;


public class PlatformProfile: Profile
{
    public PlatformProfile()
    {
        CreateMap<Platform, PlatformReadDTO>();
        CreateMap<PlatformCreateDTO, Platform>();
        CreateMap<PlatformReadDTO, PlatformPublishDTO>();
    }
}
