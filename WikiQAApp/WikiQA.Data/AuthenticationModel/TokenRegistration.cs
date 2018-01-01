using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiQA.Data.AuthenticationModel
{
    class TokenRegistration
    {
        public int Userid { get; set; }
        public string Token { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
