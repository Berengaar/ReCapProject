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
    public class EfModelDal : EfEntityRepositoryBase<Model, ReCapDbContext>, IModelDal
    {
        public List<ModelDetailDto> GetModelDetails()
        {
            using (ReCapDbContext context=new ReCapDbContext())
            {
                var result = from model in context.Models
                             join brand in context.Brands
                             on model.BrandId equals brand.BrandId
                             select new ModelDetailDto
                             {
                                 ModelId = model.ModelId,
                                 BrandName = brand.BrandName,
                                 ModelName = model.ModelName,
                                 ModelTypeId = model.ModelTypeId,
                                 ModelYear = model.ModelYear
                             };

                return result.ToList();
            }
        }
    }
}
