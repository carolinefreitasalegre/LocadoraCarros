﻿using Application.Dtos.Response.CreateCarResponse;
using Application.Dtos.Response.ResponseAdmin;
using Application.Dtos.Response.ResponseClient;
using AutoMapper;
using Domain.Entities.Admin;
using Domain.Entities.Cars;
using Domain.Entities.RentalClient;

namespace Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin, CreateAdmiResponse>();
            CreateMap<Cars, CreateCarResponse>();
            CreateMap<RentalClient, CreateRentalClientResponse>();
        }
    }
}
