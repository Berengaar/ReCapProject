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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> Add(Customer customer)
        {
            return new SuccessDataResult<List<Customer>>(Messages.Customer+Messages.Added);
        }

        public IDataResult<List<Customer>> Delete(Customer customer)
        {
            return new SuccessDataResult<List<Customer>>(Messages.Customer+Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<Customer>> Update(Customer customer)
        {
            return new SuccessDataResult<List<Customer>>(Messages.Customer+Messages.Deleted);
        }
    }
}
