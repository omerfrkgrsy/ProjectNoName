using AutoMapper;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Business.Dto;
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
            CreateMap<UserRegisterDto, User>();
        }

    }
}
