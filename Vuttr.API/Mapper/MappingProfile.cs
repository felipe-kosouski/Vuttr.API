using AutoMapper;
using Vuttr.API.Domain.DTO.Tool;
using Vuttr.API.Domain.DTO.User;
using Vuttr.API.Domain.Models;

namespace Vuttr.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tool, ToolDto>().ReverseMap();
            CreateMap<ToolForCreationDto, Tool>();
            CreateMap<ToolForUpdateDto, Tool>();

            CreateMap<UserForRegistrationDto, User>();
        }
    }
}