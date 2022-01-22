﻿using ProjectNoName.Core.Entity;
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
        public string UserId { get; set; }
        public string Email { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; }

    }
}