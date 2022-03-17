using ProjectNoName.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Entities.Concrete
{
    [Table("POST")]
    public class Post : EntityBase,IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
        public int UserId { get; set; }
        public int? ParentId { get; set; }
        public User User { get; set; }
        public Post Parent { get; set; }
        public virtual ICollection<Post> SubPosts { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

    }
}
