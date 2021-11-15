using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBG.Visitor.Storage.Models;
using NBG.Visitor.Storage.Dtos;
using AutoMapper;

namespace NBG.Visitor.Services.DB.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Visit, VisitDto>()
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
                .ForMember(dest => dest.ContactPerson, opt => opt.MapFrom(src => src.ContactPerson))
                .ForMember(dest => dest.Visitor, opt => opt.MapFrom(src => src.Visitor));
            CreateMap<VisitDto, Visit>()
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
                .ForMember(dest => dest.ContactPerson, opt => opt.MapFrom(src => src.ContactPerson))
                .ForMember(dest => dest.Visitor, opt => opt.MapFrom(src => src.Visitor));

            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
            CreateMap<ContactPerson, ContactPersonDto>();
            CreateMap<ContactPersonDto, ContactPerson>();
            CreateMap<Storage.Models.Visitor, VisitorDto>();
            CreateMap<VisitorDto, Storage.Models.Visitor>();
        }
    }
}
