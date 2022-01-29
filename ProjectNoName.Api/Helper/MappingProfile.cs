
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
            CreateMap<UserRegisterDto, User>().ForMember(x => x.UserName, opt => opt.MapFrom(o => generateUserName(o.Name, o.Surname)));
        }


        private string generateUserName(string name,string surname)
        {
            string userName = RemoveDiacritics(name) + RemoveDiacritics(surname);

            return userName;
        }

        public static string RemoveDiacritics(string text)
        {
            var unaccentedText = String.Join("", text.Normalize(NormalizationForm.FormD)
        .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));

            return unaccentedText;
        }
    }
}
