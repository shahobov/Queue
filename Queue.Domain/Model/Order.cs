using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue.Domain.Abstract;

namespace Queue.Domain.Model
{
    public class Order : EntityBase
    {
        public virtual Client Client { get; set; }
        public ulong ClientId { get; set; } 
        public virtual Worker Worker { get; set; }
        public ulong WorkerId { get; set; }
        public List<OrderDetils> OrderDetils { get; set; }
        public int Days { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalPrice { get; set; }
        public int OrderStatus { get; set; }

    }
}
