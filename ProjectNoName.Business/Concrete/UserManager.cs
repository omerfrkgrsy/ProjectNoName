using ProjectNoName.Data.Abstract;
using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Business.Concrete
{
    public class UserManager : AbstractDalService<User>
    {
        public UserManager(IUserRepository dal) :base(dal)
        {
        }

        
    }
}
