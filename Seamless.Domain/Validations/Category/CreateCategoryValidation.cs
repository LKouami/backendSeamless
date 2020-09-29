using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Seamless.Domain.Commands.Category;
using FluentValidation;

namespace Seamless.Domain.Validations.Category
{
    public class CreateCategoryValidation : AbstractValidator<CreateCategoryCommand>
    {
        SeamlessContext _dbContext;

        public CreateCategoryValidation(SeamlessContext dbContext)
        {
            _dbContext = dbContext;
         
            
            RuleFor(x => x.Name).Must(BeNotADuplicate)
                .WithMessage("There is already another Category with the same name");
        }

        private bool BeNotADuplicate(string name)
        {
            bool existAlready = _dbContext.SCategory.Any(d => d.Name.ToLower().Equals(name.ToLower()));

            return !existAlready;
        }
    }
}
