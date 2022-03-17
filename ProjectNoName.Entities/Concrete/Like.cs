using ProjectNoName.Core.Entity;
using ProjectNoName.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Entities
{
    public class Like : EntityBase, IEntity
    {
        [Column("UserId")]
        public int Id { get; set; }
        public int PostId { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }

    }
}
