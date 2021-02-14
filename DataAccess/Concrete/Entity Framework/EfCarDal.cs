using Core.DataAccess.Entity_framework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
    {
        //IEntitiesRepository'de tanımlanan metotlar entity framework için burda uygulanır
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDbContext context= new ReCapDbContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new CarDetailDto 
                             {
                                 CarId = car.CarId, CategoryId = car.CategoryId, ColorId = color.ColorId, 
                                 DailyPrice = car.DailyPrice, ModelYear = car.ModelYear 
                             };
                return result.ToList();
            }
        }
    }
}
