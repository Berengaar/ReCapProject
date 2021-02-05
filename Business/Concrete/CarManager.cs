using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _car;        //Business'ın bildiği tek nesne

        public CarManager(ICarDal carDal)
        {
            _car = carDal;
        }

        public List<Car> GetAll()
        {
            return _car.GetAll();
        }
    }
}
