using AutoMapper;
using VisitorService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorService.Models;

namespace VisitorService.Profiles
{
    public class VisitorsProfile : Profile
    {
        public VisitorsProfile()
        {
            //Source -> Target
            CreateMap<Visitor, ReadVisitorDto>();
            CreateMap<CreateVisitorDto, Visitor>();
            CreateMap<UpdateVisitorDto, Visitor>();
        }
    }
}
