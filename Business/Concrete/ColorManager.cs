using Business.Abstract;
using Business.BusinessAspect;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Cashing;
using Core.Aspects.Autofac.Validation;
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

        [SecuredOperation("member,Add.Color")]
        [ValidationAspect(typeof(ColorValidator))]
        [CasheRemoveAspect("Add.Color")]
        public IResult Add(Color color)
        {
            return new SuccessDataResult<List<Color>>(Messages.Color + Messages.Added);
        }

        [SecuredOperation("member,Delete.Color")]
        [CasheRemoveAspect("Add.Color")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Color + Messages.Deleted);
        }
        [CasheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }
        [CasheAspect]
        public IDataResult<List<Color>> GetById(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == colorId));
        }
        [ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("member,Update.Color")]
        [CasheRemoveAspect("Update.Color")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.Color + Messages.Updated);
        }
    }
}
