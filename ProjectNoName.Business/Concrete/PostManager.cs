using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Service.Concrete;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Repository.EntityFramework.Abstract;

namespace ProjectNoName.Business.Concrete
{
    public class PostManager : AbstractDalService<Post>,IPostService
    {
        public PostManager(IPostRepository dal) :base(dal)
        {

        }

    }
}
