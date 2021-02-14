using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IModelService
    {
        List<Model> GetAll(Expression<Func<Car, bool>> filter = null);
        List<Model> GetById(int modelId);
        void Add(Model model);
        void Delete(Model model);
        void Update(Model model);
        List<ModelDetailDto> GetModelDetails();
    }
}
