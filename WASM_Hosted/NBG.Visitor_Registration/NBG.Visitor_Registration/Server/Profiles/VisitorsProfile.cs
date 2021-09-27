using AutoMapper;
using NBG.Visitor_Registration.Server.Dtos;
using NBG.Visitor_Registration.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBG.Visitor_Registration.Server.Profiles
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
