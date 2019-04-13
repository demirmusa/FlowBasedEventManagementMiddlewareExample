using EFCore.GenericRepository;
using EFCore.GenericRepository.interfaces;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Business
{
    public interface ISMSDbContextGenericRepository<TEntity> : IGenericRepository<SMSDbContext, TEntity>
        where TEntity : BaseDbEntity
    {

    }
}
