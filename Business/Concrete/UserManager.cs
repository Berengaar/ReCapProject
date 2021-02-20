using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.Password.Length <= 5)
            {
                return new ErrorDataResult<List<User>>(Messages.ErrorPassword);
            }
            return new SuccessDataResult<List<User>>(Messages.Added);
        }

        public IResult Delete(User user, int userId)
        {
            return new SuccessDataResult<List<User>>(Messages.User+Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.User + Messages.Listed);
        }

        public IDataResult<List<User>> GetUsersByUserId(int userId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.UserId == userId));
        }

        public IResult Update(User user)
        {
            return new SuccessDataResult<List<User>>(Messages.User+Messages.Updated);
        }
    }
}
