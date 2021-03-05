using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ModelValidator:AbstractValidator<Model>
    {
        public  ModelValidator()
        {
            RuleFor(m => m.ModelName).Length<Model>(2, 15).WithMessage(Messages.ModelNameLength);
            RuleFor(m => m.ModelName).NotEmpty().WithMessage(Messages.ModelNameLength);
            
        }
    }
}
