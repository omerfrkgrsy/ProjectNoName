using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Business.Dto
{
    public class PostCreateDto
    {
        public string Content { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
        public int UserId { get; set; }
        public int? ParentId { get; set; }
    }
}
