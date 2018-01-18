using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto 
            Mapper.CreateMap<Customer, CustomerDtos>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MemberShipType, MembershipTypeDto>();
            Mapper.CreateMap<GenreTypes, GenreDto>();

            //Dto to Domain
           
            Mapper.CreateMap<CustomerDtos, Customer>();
            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}