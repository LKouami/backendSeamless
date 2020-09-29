using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Seamless.Domain.Commands.AppParameter;
using FluentValidation;

namespace Seamless.Domain.Validations.AppParameter
{
    public class CreateAppParameterValidation : AbstractValidator<CreateAppParameterCommand>
    {
        SeamlessContext _dbContext;

        public CreateAppParameterValidation(SeamlessContext dbContext)
        {
            _dbContext = dbContext;
         
            RuleFor(x => x.ParameterName).NotNull();

            RuleFor(x => x.ParameterName).Length(2, 255)
                .WithMessage("lenght must not exceed 255 characters");

            RuleFor(x => x.ParameterName).Must(BeNotADuplicate)
                .WithMessage("There is already another app parameter with the same name");
        }

        private bool BeNotADuplicate(string parameterName)
        {
            bool existAlready = _dbContext.SAppParameter.Any(d => d.ParameterName.ToLower().Equals(parameterName.ToLower()));

            return !existAlready;
        }
    }
}
