using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Domain.Model
{
    public class Client : EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Age { get; set; }
        public bool Gender { get; set; }

    }
}
