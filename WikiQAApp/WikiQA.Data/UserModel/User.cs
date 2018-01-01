using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiQA.Data.UserModel
{
    class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public int RoleId { get; set; }

    }
}
