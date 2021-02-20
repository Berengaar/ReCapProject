using Core.DataAccess.Entity_framework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,ReCapDbContext>,IRentalDal
    {
    }
}
