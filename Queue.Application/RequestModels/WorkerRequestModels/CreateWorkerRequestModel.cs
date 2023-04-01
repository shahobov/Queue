using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.RequestModels.WorkerRequestModels
{
    public class CreateWorkerRequestModel : WorkerRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Age { get; set; }
        public bool Gender { get; set; }
        public ulong JobId { get; set; }
        public ulong ScheduleId { get; set; }
    }
}
