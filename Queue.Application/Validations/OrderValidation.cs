using FluentValidation;
using Queue.Application.RequestModels.JobRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Validations
{
    public class OrderValidation : AbstractValidator<CreateOrderRequestModel>
    {
        public OrderValidation()
        {
            RuleFor(x => x.ClientId).NotNull().NotEmpty();

        }
    }
}
