﻿using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.ResponseModels.ScheduleResponseModels
{
    public class CreateScheduleResponseModel : ScheduleResponseModel
    {
        public ulong WorkerId { get; set; }
        public int Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBusy { get; set; }

    }
}
