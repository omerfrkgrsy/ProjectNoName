using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Data.Abstract
{
    public interface IUserRepository : IEfBaseRepository<User>
    {

    }
}
