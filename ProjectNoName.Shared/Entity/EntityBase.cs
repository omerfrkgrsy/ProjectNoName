using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Shared.Entity
{
    public abstract class EntityBase
    {
        public  bool IsActive { get; set; } 
        public  DateTime CreatedDate { get; set; } 
        public  DateTime ModifiedDate { get; set; } 

    }
}
