using Business.Constants;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator :AbstractValidator<User>
    {
        IUserDal _userDal;

        public UserValidator(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage(Messages.MinimumLength);
            RuleFor(u => u.LastName).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage(Messages.MinimumLength);
            RuleFor(u => u.Email).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(u => u.Email).MinimumLength(10).WithMessage(Messages.MinimumLength);
            RuleFor(u => u.Email).EmailAddress().WithMessage(Messages.EmailCheck);
            //RuleFor(u => u.Email).Must(IsEmailUnique).WithMessage(Messages.IsEmailUnique);
            RuleFor(u => u.PasswordHash).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(u => u.PasswordSalt).NotEmpty().WithMessage(Messages.NotEmpty);
        }
    }
}
