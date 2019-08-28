using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripPlanner.DAL.Entities;
using TripPlannerAPI.DTOs;

namespace TripPlannerAPI.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();            
            CreateMap<Trip, TripDTO>();
            CreateMap<TripDTO,Trip>();
            CreateMap<Stay, StayDTO>();
            CreateMap<StayDTO, Stay>();
            CreateMap<Document, DocumentDTO>();
            CreateMap<Address, AddressDTO>();            
            CreateMap<WebLink, WebLinkDTO>();
        }
    }
}
