﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Domain.Model
{
    public class Job : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
