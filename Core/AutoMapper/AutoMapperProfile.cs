﻿using AutoMapper;
using Core.Dto.DtoAuthorization;
using Core.Dto.DtoBooking;
using Core.Dto.DtoBookingDetail;
using Core.Dto.DtoCategories;
using Core.Dto.DtoServices;
using Core.Dto.DtoUser;
using Core.Entities;
using Data.Entities;

namespace Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookingDto, BookingEntity>().ReverseMap();
            CreateMap<CreateBookingDto, BookingEntity>();
            CreateMap<UpdateBookingDto, BookingEntity>();

            CreateMap<BookingDetailDto, BookingDetailEntity>().ReverseMap();
            CreateMap<CreateBookingDetailDto, BookingDetailEntity>();
            CreateMap<UpdateBookingDetailDto, BookingDetailEntity>();

            CreateMap<ServiceDto, ServiceEntity>().ReverseMap();
            CreateMap<CreateServiceDto, ServiceEntity>();
            CreateMap<UpdateServiceDto, ServiceEntity>();

            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<RegisterDto, UserEntity>()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)); CreateMap<CreateUserDto, UserEntity>();
            CreateMap<UpdateUserDto, UserEntity>();

            CreateMap<CategoryDto, CategoryEntity>().ReverseMap();
            CreateMap<CreateCategoryDto, CategoryEntity>();
            CreateMap<UpdateCategoryDto, CategoryEntity>();
        }
    }
}
