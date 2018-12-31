using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace B03.EE.BlanckeK.Api.Repositories.Base
{
    public class MainRepository<T> : IMainRepository<T> where T : EntityBase
    {

        protected readonly QuizContext Db;

        public MainRepository(QuizContext db)
        {
            Db = db;
        }
        
        public virtual async Task<T> GetById(string id)
        {
            return await Db.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return Db.Set<T>().AsNoTracking();
        }

        public async Task<IEnumerable<T>> ListAll()
        {
            return await GetAll().ToListAsync();
        }

        public virtual IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate)
        {
            return Db.Set<T>().Where(predicate).AsNoTracking();
        }

        public virtual async Task<IEnumerable<T>> ListFiltered(Expression<Func<T, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            Db.Set<T>().Add(entity);
            try
            {
                await Db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            Db.Set<T>().Remove(entity);
            try
            {
                await Db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(string id)
        {
            var entity = await GetById(id);
            if (entity == null) return null;
            return await Delete(entity);
        }

        public async Task<T> Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            try
            {
                await Db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        private async Task<bool> Exists(string id)
        {
            return await Db.Set<T>().AnyAsync(e => e.Id == id);
        }
    }
}
