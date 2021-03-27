using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car {CategoryId=1,ModelYear="2018",DailyPrice=200000,BrandName="s" },
                new Car {CategoryId=2,ModelYear="2019",DailyPrice=240000,BrandName="s" },
                new Car {CategoryId=3,ModelYear="2020",DailyPrice=290000,BrandName="s" },
                new Car {CategoryId=4,ModelYear="2014",DailyPrice=80000,BrandName="i" },
                new Car {CategoryId=5,ModelYear="2012",DailyPrice=60000,BrandName="si" }
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);  //GÖnderdiğim araba parametresini kullan _car listesine ekle
        }

        public void Delete(Car car)
        {
           
            Car carToDelete = null;
            carToDelete = _car.SingleOrDefault(c => c.CategoryId == car.CategoryId);
            _car.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;    //Tüm araba listesini gönder.
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _car.Where(c => c.CategoryId == id).ToList();
        }

        public List<CarDetailDto> GetCarDetailsById(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate =_car.SingleOrDefault(c => c.CategoryId == car.CategoryId);
            carToUpdate.CategoryId = car.CategoryId;
            
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.BrandName = car.BrandName;

        }
    }
}
