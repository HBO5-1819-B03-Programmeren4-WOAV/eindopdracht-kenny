using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using B03.EE.BlanckeK.Lib.Models;

namespace B03.EE.BlanckeK.Api.Repositories.Base
{
    public interface IMainRepository<T> where T: EntityBase
    {
        Task<T> GetById(string id);
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> ListAll();
        IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> ListFiltered(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task<T> Delete(T entity);
        Task<T> Delete(string id);
        Task<T> Update(T entity);
    }
}
