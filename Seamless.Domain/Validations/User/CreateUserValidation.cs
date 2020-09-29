using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Seamless.Domain.Commands.User;
using FluentValidation;

namespace Seamless.Domain.Validations.User
{
    public class CreateUserValidation : AbstractValidator<CreateUserCommand>
    {
        SeamlessContext _dbContext;

        public CreateUserValidation(SeamlessContext dbContext)
        {
            _dbContext = dbContext;
         
           RuleFor(x => x.Email).Must(BeNotADuplicate)
                .WithMessage("There is already another user with the same email");
        }

        private bool BeNotADuplicate(string email)
        {
            bool existAlready = _dbContext.AUser.Any(d => d.Email.ToLower().Equals(email.ToLower()));

            return !existAlready;
        }
    }
}
