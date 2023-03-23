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
            RuleFor(x => x.FirstName).Length(0, 10);
            RuleFor(x => x.LastName).Length(0, 10);
            RuleFor(x => x.Address).Length(0, 15);
            RuleFor(x => x.Age).Length(0, 3);
            RuleFor(x => x.PhoneNumber).NotNull().Length(0, 13);
        }

        
    }
}
