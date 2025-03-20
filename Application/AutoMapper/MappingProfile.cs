using Application.Dtos.Response.CreateCarResponse;
using Application.Dtos.Response.ResponseAdmin;
using AutoMapper;
using Domain.Entities.Admin;
using Domain.Entities.Cars;

namespace Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin, CreateAdmiResponse>();
            CreateMap<Cars, CreateCarResponse>();
        }
    }
}
