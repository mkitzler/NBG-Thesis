using AutoMapper;
using NBG.Visitor.Domain.Dtos;
using NBG.Visitor.Storage.Models;

namespace NBG.Visitor.Services.DB.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Visit, VisitDto>()
                .ForMember(dest => dest.Visitor, opt => opt.MapFrom(src => src.Visitor));
            CreateMap<VisitDto, Visit>()
                .ForMember(dest => dest.Visitor, opt => opt.MapFrom(src => src.Visitor));

            CreateMap<Storage.Models.Visitor, VisitorDto>();
            CreateMap<VisitorDto, Storage.Models.Visitor>();
            CreateMap<VisitStatusDto, VisitStatus>();
            CreateMap<VisitStatus, VisitStatusDto>();
        }
    }
}
