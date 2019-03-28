using Example.EFCoreShared;
using Example.EFCoreShared.interfaces;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Business
{
    public interface IMyGenericRepository<TEntity> : IGenericRepository<SMSDbContext, TEntity>
        where TEntity : BaseDbEntity
    {

    }
}
