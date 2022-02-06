using AutoMapper;
using PostUser.Models;
using PostUser.Models.DTOs;

namespace PostUser.Application
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Posts, PostDto>().ReverseMap();
            CreateMap<Users, UserDto>().ReverseMap();
        }
    }
}
