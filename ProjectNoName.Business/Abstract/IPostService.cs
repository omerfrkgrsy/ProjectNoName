using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectNoName.Business.Dto;

namespace ProjectNoName.Business.Abstract
{
    public interface IPostService:IBaseService<Post>
    {
        Task<List<PostListDto>> GetList();
    }
}
