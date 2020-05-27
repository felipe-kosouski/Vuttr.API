using AutoMapper;
using Vuttr.API.Domain.DTO;
using Vuttr.API.Domain.DTO.Tool;
using Vuttr.API.Domain.Models;

namespace Vuttr.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tool, ToolDto>().ReverseMap();
        }
    }
}