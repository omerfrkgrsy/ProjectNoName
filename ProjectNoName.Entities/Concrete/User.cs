using ProjectNoName.Shared.Entity;
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

    }
}
