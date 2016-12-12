using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
    public class AuthenticationObject
    {
        public Boolean success { get; set; }
        public Boolean forceResetPassword { get; set; }
        public String accessToken { get; set; }
    }
}
