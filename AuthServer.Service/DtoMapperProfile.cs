using AuthServer.Core.DTOs;
using AuthServer.Core.Models;
using AutoMapper;

namespace AuthServer.Service
{
    class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<UserAppDto, UserApp>().ReverseMap();
        }
    }
}
