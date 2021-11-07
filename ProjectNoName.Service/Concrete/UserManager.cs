using ProjectNoName.Data.Abstract;
using ProjectNoName.Entities.Concrete;
using ProjectNoName.Shared.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Service.Concrete
{
    public class UserManager : AbstractDalService<User>
    {
        public UserManager(IUserRepository dal) :base(dal)
        {
        }

        
    }
}
