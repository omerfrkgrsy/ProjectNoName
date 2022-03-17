using ProjectNoName.Core.Entity;
using ProjectNoName.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Entities
{
    public class RelationShip : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int FollewerId { get; set; }
        public int FollowedId { get; set; }
        public bool isBlocked { get; set; }
        public User Follewer { get; set; }
        public User Follewed { get; set; }
    }
}
