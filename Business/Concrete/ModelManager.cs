using Business.Abstract;
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
        public void Add(Model model)
        {
            _modelDal.Add(model);
        }

        public void Delete(Model model)
        {
            _modelDal.Delete(model);
        }


        public List<Model> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _modelDal.GetAll();
        }

        public List<Model> GetById(int modelId)
        {
            return _modelDal.GetAll(m => m.ModelId == modelId);
        }

        public List<ModelDetailDto> GetModelDetails()
        {
            return _modelDal.GetModelDetails();
        }

        public void Update(Model model)
        {
            _modelDal.Update(model);
        }
    }
}
