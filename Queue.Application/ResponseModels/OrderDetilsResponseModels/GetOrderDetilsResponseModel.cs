﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.ResponseModels.OrderDetilsResponseModels
{
    public class GetOrderDetilsResponseModel :OrderDetilsResponseModel
    {
        public ulong OrderId { get; set; }
        public ulong ServiceId { get; set; }
    }
}
