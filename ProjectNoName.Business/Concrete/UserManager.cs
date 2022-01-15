using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Repository.Abstract;

namespace ProjectNoName.Business.Concrete
{
    public class UserManager : AbstractDalService<User>,IUserService
    {
        public UserManager(IUserRepository dal) :base(dal)
        {
        }

        
    }
}
