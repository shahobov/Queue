using Queue.Application.Common.Interfaces;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public class ClientService : BaseService<Client>, IClientService
    {
        public override Client Get(ulong id)
        {
            if(id == 1)
            {
                return new Client() 
                { 
                    FirstName ="Samadjon",
                    Address = "Istaravshan"
                };
            }
            return new Client() 
            { 
                FirstName ="Client not found"
            };
        }
    }
}
