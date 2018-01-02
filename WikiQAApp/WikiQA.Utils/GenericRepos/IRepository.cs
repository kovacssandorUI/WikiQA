using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WikiQA.Utils.GenericRepos
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<int> DeleteByIdAsync(int id);
        Task<int> DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> condition);
        void Insert(TEntity entity);

    }
}
