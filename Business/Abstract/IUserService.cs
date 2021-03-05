using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<User>> GetAll();
        User GetByMail(string email);
        IDataResult<List<User>> GetById(int Id);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
