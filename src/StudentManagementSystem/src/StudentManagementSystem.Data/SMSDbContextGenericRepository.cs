using EFCore.GenericRepository;
using StudentManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.BLL
{
    public class SMSDbContextGenericRepository<TEntity> : GenericRepository<SMSDbContext, TEntity>, ISMSDbContextGenericRepository<TEntity>
        where TEntity : BaseDbEntity
    {
        public SMSDbContextGenericRepository(SMSDbContext context) : base(context)
        {
            //context.Database.EnsureCreated();
        }
    }
}
