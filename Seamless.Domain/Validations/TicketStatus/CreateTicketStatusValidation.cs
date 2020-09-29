using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Seamless.Domain.Commands.TicketStatus;
using FluentValidation;

namespace Seamless.Domain.Validations.TicketStatus
{
    public class CreateTicketStatusValidation : AbstractValidator<CreateTicketStatusCommand>
    {
        SeamlessContext _dbContext;

        public CreateTicketStatusValidation(SeamlessContext dbContext)
        {
            _dbContext = dbContext;
         
           RuleFor(x => x.Name).Must(BeNotADuplicate)
                .WithMessage("There is already another TicketStatus with the same name");
        }

        private bool BeNotADuplicate(string name)
        {
            bool existAlready = _dbContext.STicketStatus.Any(d => d.Name.ToLower().Equals(name.ToLower()));

            return !existAlready;
        }
    }
}
