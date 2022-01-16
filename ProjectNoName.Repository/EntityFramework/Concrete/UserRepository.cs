using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Data.Concrete;
using ProjectNoName.Repository.EntityFramework.Context;
using ProjectNoName.Repository.EntityFramework.Abstract;

namespace ProjectNoName.Repository.EntityFramework.Concrete
{
    public class UserRepository : EfBaseRepository<User>,IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
        
    }
}
