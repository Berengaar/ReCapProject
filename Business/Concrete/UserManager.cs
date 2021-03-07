using Business.Abstract;
using Business.BusinessAspect;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Cashing;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    [SecuredOperation("Admin,Moderator")]
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        
        [ValidationAspect(typeof(UserValidator))]
        [CasheRemoveAspect("Add.User")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        
        [CasheRemoveAspect("Delete.User")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.User+Messages.Deleted);
        }
        [CasheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.User + Messages.Listed);
        }
        [CasheAspect]
        public List<OperationClaim> GetClaims(User user)
        {
            return new List<OperationClaim>(_userDal.GetClaims(user));
        }
        [CasheAspect]
        public IDataResult<List<User>> GetById(int Id)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Id == Id));
        }

        
        [ValidationAspect(typeof(UserValidator))]
        [CasheRemoveAspect("Update.User")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.User+Messages.Updated);
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
