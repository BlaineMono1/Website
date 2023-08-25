using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rocky_DataAccess.Repository.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(int id);
        IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity,bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy =null,
            string includeProperties = null,
            bool isTracking = true
            );
        TEntity FirstOrDefault(
             Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null,
            bool isTracking = true

            );

        void Add(TEntity entity);
        void Remove(TEntity entity);

        void Save();

    }
}
