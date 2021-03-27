using Business.Abstract;
using Business.BusinessAspect;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Cashing;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileOperations;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        
        [ValidationAspect(typeof(CarImageValidator))]
        
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            carImage.CountOfCarImage += 1;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        [SecuredOperation("carImages.delete,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        
        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
            //FileHelper.Delete(carImage.ImagePath);
           
            if (carImage.CountOfCarImage > 0)
            {
                carImage.CountOfCarImage -= 1;
                _carImageDal.Delete(carImage);
                return new SuccessResult();
            }
            else { return new ErrorResult(); }
            
        }

        
        [PerformanceAspect(5)]
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        
        [PerformanceAspect(10)]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [PerformanceAspect(5)]
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId).Data);
        }

        [SecuredOperation("carImages.update,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        
        public IResult Update(IFormFile file, CarImage carImage)
        {
            //carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }


        //*************************************************************************************

        private IResult CheckIfImageLimit(int carid)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int carId)
        {
            string path = "/images/null.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).ToList();
            if (result.Count == 0)
            {
                
                List<CarImage> carImage = new List<CarImage>();
                carImage.Add(new CarImage
                {
                    CarId = carId,
                    Date = DateTime.Now,
                    ImagePath = path,
                });
                return new SuccessDataResult<List<CarImage>>(carImage);
            }
            return new SuccessDataResult<List<CarImage>>(result);
            
        }

        public IResult GetList(List<CarImage> list)
        {
            Console.WriteLine("\n------- Car Image List -------");

            foreach (var img in list)
            {
                Console.WriteLine("{0}- Car ID: {1}\n    Image Path: {2}\n    CratedAt: {3}\n", img.Id, img.CarId, img.ImagePath, img.Date);
            }
            return new SuccessResult();
        }

        public IDataResult<CarImage> FindByID(int Id)
        {
            CarImage img = new CarImage();
            if (_carImageDal.GetAll().Any(x => x.CarId == Id))
            {
                img = _carImageDal.GetAll().FirstOrDefault(x => x.CarId == Id);
            }
            else Console.WriteLine("No such car image was found.");
            return new SuccessDataResult<CarImage>(img);
        }

        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                FileHelper.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}
