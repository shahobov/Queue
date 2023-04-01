﻿using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.RequestModels.OrderRequestModels
{
    public abstract class OrderRequestModel : BaseRequestModel
    {
        
        public ulong ServiceId { get; set; }
        public ulong ClientId { get; set; }
        public ulong WorkerId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan StartServiceTimes { get; set; }
        public TimeSpan EndExequteTImeService { get; set; }
        public int QueueStatus { get; set; }
    }
}
