using ProjectNoName.Entities.Concrete;
using ProjectNoName.Core.Service.Concrete;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Repository.EntityFramework.Abstract;
using System.Collections.Generic;
using ProjectNoName.Business.Dto;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjectNoName.Business.Concrete
{
    public class PostManager : AbstractDalService<Post>,IPostService
    {
        readonly IPostRepository _postRepository;
        readonly IUserRepository _userRepository;
        public PostManager(IPostRepository dal, IUserRepository userRepository) :base(dal)
        {
            _postRepository = dal;
            _userRepository = userRepository;
        }

        public async Task<List<PostListDto>> GetList()
        {
            var query = await _postRepository.All().Include(x => x.Parent).Include(x => x.User).Select(x => new PostListDto
            {
                UserName = x.User.UserName,
                Name = x.User.Name,
                Surname = x.User.Surname,
                Title = x.Title,
                Content = x.Content,
                Image = x.Image,
                Audio = x.Audio,
                SubPosts = x.SubPosts.Select(x=> new PostListDto
                {
                    UserName = x.User.UserName,
                    Name = x.User.Name,
                    Surname = x.User.Surname,
                    Title = x.Title,
                    Content = x.Content,
                    Image = x.Image,
                    Audio = x.Audio,
                    SubPosts = new List<PostListDto>()
                }).ToList()
            }).ToListAsync();

            return query;
        }
    }
}
