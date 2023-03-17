using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Domain.Model
{
    public class EntityBase
    {
       
        public ulong Id { get; set; }
        public DateTime LastOperationDateTime { get; set; }
    }
}
