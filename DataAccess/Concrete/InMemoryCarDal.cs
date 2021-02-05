using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _car = null;
        public InMemoryCarDal()
        {
            List<Car> _car = new List<Car>
            {
                new Car {CategoryId=1,BrandId=1,ColorId=4,ModelYear="2018",DailyPrice=200000,Description="s" },
                new Car {CategoryId=2,BrandId=2,ColorId=6,ModelYear="2019",DailyPrice=240000,Description="s" },
                new Car {CategoryId=3,BrandId=2,ColorId=22,ModelYear="2020",DailyPrice=290000,Description="s" },
                new Car {CategoryId=4,BrandId=3,ColorId=1,ModelYear="2014",DailyPrice=80000,Description="i" },
                new Car {CategoryId=5,BrandId=3,ColorId=15,ModelYear="2012",DailyPrice=60000,Description="si" }
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

        public List<Car> GetAll()
        {
            return _car;    //Tüm araba listesini gönder.
        }

        public List<Car> GetById(int id)
        {
            return _car.Where(c => c.CategoryId == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate =_car.SingleOrDefault(c => c.CategoryId == car.CategoryId);
            carToUpdate.CategoryId = car.CategoryId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}
