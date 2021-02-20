using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            return new SuccessDataResult<List<Color>>(Messages.Color + Messages.Added);
        }

        public IResult Delete(Color color)
        {
            return new SuccessDataResult<List<Color>>(Messages.Color + Messages.Deleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<List<Color>> GetById(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            return new SuccessDataResult<List<Color>>(Messages.Color + Messages.Updated);
        }
    }
}
