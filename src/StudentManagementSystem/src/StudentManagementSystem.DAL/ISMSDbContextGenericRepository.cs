using EFCore.GenericRepository;
using EFCore.GenericRepository.Interfaces;
using StudentManagementSystem.DAL;

namespace StudentManagementSystem.BLL
{
    public interface ISMSDbContextGenericRepository<TEntity> : IGenericRepository<SMSDbContext, TEntity>
        where TEntity : BaseDbEntity
    {

    }
}
