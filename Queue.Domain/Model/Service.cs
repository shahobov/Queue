using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue.Domain.Abstract;

namespace Queue.Domain.Model
{
    public class Service : EntityBase
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public ulong CategoryId { get; set; }
        public string Description { get; set; }
        public int ExecutionTime { get; set; }
        public decimal Price { get; set; }
    }
}
