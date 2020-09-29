using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Seamless.Domain.Commands.Assignment;
using FluentValidation;

namespace Seamless.Domain.Validations.Assignment
{
    public class CreateAssignmentValidation : AbstractValidator<CreateAssignmentCommand>
    {
        SeamlessContext _dbContext;

        public CreateAssignmentValidation(SeamlessContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.AssigneeId).Must(BeNotADuplicate)
                .WithMessage("There is already another Assignment with the same AssigneeId");
        }

        private bool BeNotADuplicate(long? assigneeId)
        {
            bool existAlready = _dbContext.SAssignment.Any(d => d.AssigneeId.Equals(assigneeId));

            return !existAlready;
        }
    }
}
