using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Seamless.Domain.Commands.Faq;
using FluentValidation;

namespace Seamless.Domain.Validations.Faq
{
    public class CreateFaqValidation : AbstractValidator<CreateFaqCommand>
    {
        SeamlessContext _dbContext;

        public CreateFaqValidation(SeamlessContext dbContext)
        {
            _dbContext = dbContext;
         
            RuleFor(x => x.Title).Must(BeNotADuplicate)
                .WithMessage("There is already another Faq with the same title");
        }

        private bool BeNotADuplicate(string title)
        {
            bool existAlready = _dbContext.SFaq.Any(d => d.Title.ToLower().Equals(title.ToLower()));

            return !existAlready;
        }
    }
}
