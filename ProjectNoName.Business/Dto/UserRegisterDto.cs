using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Business.Dto
{
    public class UserRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pasword { get; set; }
        public string RePasword { get; set; }
        public string Email { get; set; }
    }
}
