using Business.Abstract;
using Business.BusinessAspect;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    [SecuredOperation("Administrator,Manager")]
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("AddCustomer")]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessDataResult<List<Customer>>(Messages.Customer+Messages.Added);
        }

        [SecuredOperation("DeleteCustomer")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessDataResult<List<Customer>>(Messages.Customer+Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("UpdateCustomer")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessDataResult<List<Customer>>(Messages.Customer+Messages.Deleted);
        }
    }
}
