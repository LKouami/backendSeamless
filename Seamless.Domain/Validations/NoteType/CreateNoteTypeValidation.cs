using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Seamless.Domain.Commands.NoteType;
using FluentValidation;

namespace Seamless.Domain.Validations.NoteType
{
    public class CreateNoteTypeValidation : AbstractValidator<CreateNoteTypeCommand>
    {
        SeamlessContext _dbContext;

        public CreateNoteTypeValidation(SeamlessContext dbContext)
        {
            _dbContext = dbContext;
         
            
            RuleFor(x => x.Name).Must(BeNotADuplicate)
                .WithMessage("There is already another note type with the same name");
        }

        private bool BeNotADuplicate(string name)
        {
            bool existAlready = _dbContext.SNoteType.Any(d => d.Name.ToLower().Equals(name.ToLower()));

            return !existAlready;
        }
    }
}
