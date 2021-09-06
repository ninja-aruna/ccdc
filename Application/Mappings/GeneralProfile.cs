using Application.Features.Structures.Commands.CreateStructure;
using Application.Features.Structures.Queries.GetAllStructures;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Structure, GetAllStructuresViewModel>().ReverseMap();
            CreateMap<CreateStructureCommand, Structure>();
            CreateMap<GetAllStructuresQuery, GetAllStructuresParameter>();
        }
    }
}
