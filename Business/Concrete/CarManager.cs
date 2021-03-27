using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspect;
using Core.Aspects.Autofac.Cashing;

namespace Business.Concrete
{ 
    public class CarManager : ICarService
    {
        ICarDal _carDal;        //Business'ın bildiği tek nesne
        //İş kodları burda olur
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("member")]
        [CasheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.Car + Messages.Added);
            }
            return new ErrorResult();    
        }
        [SecuredOperation("member")]
        [CasheRemoveAspect("Delete.Car")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Car + Messages.Deleted);
        }

        
        [CasheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Car>>(Messages.Meintanance);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Car + Messages.Listed);
        }

        [CasheAspect]
        public IDataResult<List<CarDetailDto>> GetAllCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId)
        {
            var result = _carDal.GetAllCarDetails(c => c.CarId == carId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(new List<CarDetailDto>());
            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        //[CasheAspect]
        //public IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsById(c=>c.CarId==carId));
        //}
        [CasheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }
        [CasheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }
        
        [SecuredOperation("member")]
        [ValidationAspect(typeof(CarValidator))]
        [CasheRemoveAspect("Update.Car")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Car + Messages.Updated);
        }
    }
}
