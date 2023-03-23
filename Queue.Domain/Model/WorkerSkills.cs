using Queue.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Domain.Model
{
    public class WorkerSkills : EntityBase
    {
        public Service Services { get; set; }
        public ulong ServiceID { get; set; }
        public Worker Workers { get; set; }
        public ulong WorkerID { get; set; }

    }
}
