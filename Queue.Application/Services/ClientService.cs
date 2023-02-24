using Queue.Application.Common.Interfaces;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public class ClientService : BaseService<Client>, IClientSevice
    {
        public override Client Get(ulong id)
        {
            if(id == 1)
            {
                return new Client() 
                { 
                    Name ="Samadjon"
                };
            }
            return new Client() 
            { 
                Name ="Client not found"
            };
        }
    }
}
