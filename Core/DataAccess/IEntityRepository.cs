using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Kullanılacak metot tipleri burda tanımlanır ilk olarak
    public interface IEntityRepository<T> where T:class,IEntity,new()     //Generic class ---------- Generic Constraint(generic kısıtlama)
    {

        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
