using FluentValidation;
using Queue.Application.RequestModels.ClientRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Validations
{
    public class CreateClientValidation : AbstractValidator<CreateClientRequestModel>
    {
        public CreateClientValidation()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MinimumLength(2).MinimumLength(20);
            RuleFor(x => x.LastName).Length(1, 10);
            RuleFor(x => x.Address).Length(1, 15);
            RuleFor(x => x.Age).Length(1, 3);
            RuleFor(x => x.PhoneNumber).MaximumLength(9).MinimumLength(9);
        }

        
    }
}
