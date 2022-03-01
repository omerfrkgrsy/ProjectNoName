using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Business.Dto
{
    public class PostListDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
        public virtual ICollection<PostListDto> SubPosts { get; set; }
    }
}
