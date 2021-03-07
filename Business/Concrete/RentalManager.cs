using Business.Abstract;
using Business.BusinessAspect;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Cashing;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [SecuredOperation("Add.Rental")]
        [ValidationAspect(typeof(RentalValidator))]
        [CasheRemoveAspect("Add.Rental")]
        public IResult Add(Rental rental)
        {
            if (_rentalDal.Get(r=>r.CarId==rental.CarId).ReturnDate==null )
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Rental + Messages.Added);     
            }
            return new ErrorResult(Messages.ErrorRental);
        }

        [SecuredOperation("Delete.Rental")]
        [CasheRemoveAspect("Delete.Rental")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Rental + Messages.Deleted);
        }
        [CasheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Rental+Messages.Listed);
        }
        [CasheAspect]
        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == Id));
        }

        [SecuredOperation("Update.Rental")]
        [CasheRemoveAspect("Update.Rental")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Rental+Messages.Updated);
        }
    }
}
