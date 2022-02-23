using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Service.Concrete;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Repository.EntityFramework.Abstract;
using System.Threading.Tasks;
using System.Text;
using System;
using System.Linq;
using System.Globalization;

namespace ProjectNoName.Business.Concrete
{
    public class UserManager : AbstractDalService<User>,IUserService
    {
        IUserRepository _userRepository;
        public UserManager(IUserRepository dal) :base(dal)
        {
            _userRepository = dal;
        }

        public async new Task<User> Insert(User entity)
        {
            entity.UserName= generateUserName(entity.Name, entity.Surname);
            return await _dal.AddAsync(entity);
        }
        private string generateUserName(string name, string surname)
        {
            string userName = RemoveDiacritics(name) + RemoveDiacritics(surname);
            return generatedUserName(userName);
        }

        public static string RemoveDiacritics(string text)
        {
            var unaccentedText = String.Join("", text.Normalize(NormalizationForm.FormD)
        .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));

            return unaccentedText;
        }

        private string generatedUserName(string userName)
        {
            Random random = new Random();
            int rand = 0;
            string realUser = userName;
            int i = 1;
            while (_userRepository.All().Any(x => x.UserName == userName))
            {
                if (i%90 == 0)
                {
                    rand = random.Next(((i / 90)) * 90, ((i/90)+1)*90);
                }
                else
                {
                    rand = random.Next(10, 90);
                }
                i++;

                userName = realUser + rand;
            }
            return userName;
        }
    }
}
