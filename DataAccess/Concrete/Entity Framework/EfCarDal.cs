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

        public List<CarDetailDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    join color in context.Colors on car.ColorId equals color.ColorId
                             join carImage in context.CarImages on car.CarId equals carImage.CarId
                             join category in context.Categories on car.CategoryId equals category.CategoryId
                             select new CarDetailDto
                    {
                        CarId = car.CarId,
                        BrandId = brand.BrandId,
                        BrandName = car.BrandName,
                        CategoryId = car.CategoryId,
                        CategoryName = category.CategoryName,
                        CarName = car.CarName,
                        ColorId = color.ColorId,
                        ColorName = color.ColorName,
                        ModelId=car.ModelId,
                        ModelYear = car.ModelYear,
                        DailyPrice = car.DailyPrice,
                        ImageId=carImage.CarId,
                        ImagePath=carImage.ImagePath
                    };
                return result.ToList();
            }
        }

    }
}
