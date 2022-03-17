using AutoMapper;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Business.Dto;
using ProjectNoName.Entities;
using ProjectNoName.Entities.Concrete;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ProjectNoName.Api.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDto, User>().ForMember(dest => dest.PasswordHash, src => src.MapFrom(s => s.Password));
            CreateMap<PostCreateDto, Post>();
            CreateMap<FollowDto, RelationShip>().ForMember(dest => dest.FollewerId, src => src.MapFrom(s => s.FollewedId))
                                                .ForMember(dest => dest.FollowedId, src => src.MapFrom(s => s.Id))
                                                .AfterMap((src, dest) => dest.isBlocked = false);
        }

    }
}