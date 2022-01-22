using ProjectNoName.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Entities.Concrete
{
    [Table("USER")]
    public class User : EntityBase,IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pasword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<User> Followers { get; set; }
        public virtual ICollection<User> Followed { get; set; }
    }
}
