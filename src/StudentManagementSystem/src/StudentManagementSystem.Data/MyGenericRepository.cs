using Example.EFCoreShared;
using StudentManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.Business
{
    public class MyGenericRepository<TEntity> : GenericRepository<SMSDbContext, TEntity>, IMyGenericRepository<TEntity>
        where TEntity : BaseDbEntity
    {
        public MyGenericRepository(SMSDbContext context) : base(context)
        {
            //context.Database.EnsureCreated();
        }
    }
}
