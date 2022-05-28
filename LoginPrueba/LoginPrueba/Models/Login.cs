using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LoginPrueba.Models
{    
    public class Login
    {        
        public string email { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string authorizationToken { get; set; }
    }
}
