


using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Example.EFCoreShared.interfaces
{
    public interface IGenericRepository<TContext, TEntity>
        where TContext : DbContext
        where TEntity : BaseDbEntity
    {
        IQueryable<TEntity> AsQueryable(bool getDeleted = false);
        TEntity Delete(int id);
        TEntity AddOrUpdate(TEntity entity);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
    }
}
