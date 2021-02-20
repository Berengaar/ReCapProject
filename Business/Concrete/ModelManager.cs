using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public IResult Add(Model model)
        {
            return new SuccessDataResult<List<Model>>(Messages.Model + Messages.Added);
        }

        public IResult Delete(Model model, int modelId)
        {
            return new SuccessDataResult<List<Model>>(Messages.Model + Messages.Deleted);
        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
        }

        public IDataResult<List<Model>> GetById(Model model)
        {
            if (Convert.ToInt32(model.ModelYear)<2000)
            {
                return new ErrorDataResult<List<Model>>(Messages.ErrorPrice);
            }
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(m => m.ModelId == model.ModelId));
        }

        public IDataResult<List<ModelDetailDto>> GetModelDetails()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<ModelDetailDto>>(Messages.Meintanance);
            }
            return new SuccessDataResult<List<ModelDetailDto>>(_modelDal.GetModelDetails());
        }

        public IResult Update(Model model)
        {
            return new SuccessDataResult<List<Model>>(Messages.Model + Messages.Updated);
        }
    }
}
