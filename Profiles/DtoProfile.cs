using AutoMapper;
using FirstProject.Dtos;
using FirstProject.Models;

namespace FirstProject.Profiles
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Project,ReadDto>();
            CreateMap<CreateDto,Project>();
            CreateMap<UpdateDto,Project>();
            CreateMap<Project,UpdateDto>();
        }
    }
}