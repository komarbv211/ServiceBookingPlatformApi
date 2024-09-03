using AutoMapper;
using Core.Dto;
using Data.Entities;

namespace Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookingDto, BookingEntity>().ReverseMap();
            CreateMap<ServiceDto, ServiceEntity>().ReverseMap();
            CreateMap<UserDto, UserEntity>().ReverseMap();
        }
    }
}
