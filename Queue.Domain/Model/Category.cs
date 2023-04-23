using Queue.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Domain.Model
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}
