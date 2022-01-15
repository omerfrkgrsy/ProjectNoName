using Microsoft.EntityFrameworkCore;
using ProjectNoName.Data.Abstract;
using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Data.Concrete
{
    public class UserRepository : EfBaseRepository<User>,IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
        
    }
}
