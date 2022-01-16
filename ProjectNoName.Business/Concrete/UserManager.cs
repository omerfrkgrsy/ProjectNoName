using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Service.Concrete;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Repository.EntityFramework.Abstract;

namespace ProjectNoName.Business.Concrete
{
    public class UserManager : AbstractDalService<User>,IUserService
    {
        public UserManager(IUserRepository dal) :base(dal)
        {
        }

        
    }
}
