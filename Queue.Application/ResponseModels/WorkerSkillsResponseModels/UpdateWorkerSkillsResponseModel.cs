﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.ResponseModels.WorkerSkillsResponseModels
{
    public class UpdateWorkerSkillsResponseModel : WorkerSkillsResponseModel
    {
        public ulong WorkerID { get; set; }
        public ulong ServiceID { get; set; }
    }
}
