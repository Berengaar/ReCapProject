using Core.Utilities.Results;
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
        IDataResult<List<Model>> GetAll();
        IDataResult<List<Model>> GetById(Model model);
        IResult Add(Model model);
        IResult Update(Model model);
        IResult Delete(Model model, int modelId);
        IDataResult<List<ModelDetailDto>> GetModelDetails();
    }
}
