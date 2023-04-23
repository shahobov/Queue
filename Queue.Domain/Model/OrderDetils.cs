using Queue.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Domain.Model
{
    public class OrderDetils : EntityBase
    {
        public virtual Order Order { get; set; }
        public ulong OrderId { get; set; }
        public virtual Service Service { get; set; }
        public ulong ServiceId { get; set; }

    }

}
