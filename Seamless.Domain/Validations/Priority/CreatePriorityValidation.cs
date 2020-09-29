using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Seamless.Domain.Commands.Priority;
using FluentValidation;

namespace Seamless.Domain.Validations.Priority
{
    public class CreatePriorityValidation : AbstractValidator<CreatePriorityCommand>
    {
        SeamlessContext _dbContext;

        public CreatePriorityValidation(SeamlessContext dbContext)
        {
            _dbContext = dbContext;
         
            RuleFor(x => x.Name).Must(BeNotADuplicate)
                .WithMessage("There is already another priority with the same name");
        }

        private bool BeNotADuplicate(string name)
        {
            bool existAlready = _dbContext.SPriority.Any(d => d.Name.ToLower().Equals(name.ToLower()));

            return !existAlready;
        }
    }
}
