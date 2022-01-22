using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Service.Concrete;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Repository.EntityFramework.Abstract;

namespace ProjectNoName.Business.Concrete
{
    public class CommentManager : AbstractDalService<Comment>,ICommentService
    {
        public CommentManager(ICommentRepository dal) :base(dal)
        {

        }

    }
}
