using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess.Entity_framework;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, ReCapDbContext>, IColorDal
    {
       
    }
}
