﻿using Example.EFCoreShared.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Example.EFCoreShared
{
    public class GenericRepository<TContext, TEntity> : IGenericRepository<TContext, TEntity>, IDisposable
        where TContext : DbContext
        where TEntity : BaseDbEntity
    {
        TContext _context;
        protected DbSet<TEntity> DbSet;

        public GenericRepository(TContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> AsQueryable(bool getDeleted = false)
        {
            if (getDeleted)
                return DbSet;
            else
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(typeof(TEntity)))
                {
                    return ((IQueryable<ISoftDeletable>)(this.DbSet))
                        .Where(q => q.Deleted == false)
                        .Cast<TEntity>();
                }
                return DbSet;
            }
        }
        public virtual TEntity Delete(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity == null)
                return null;

            if (entity is ISoftDeletable)
            {
                entity.LastUpdateTime = DateTime.Now;
                (entity as ISoftDeletable).Deleted = true;
            }
            else
                DbSet.Remove(entity);

            Commit();
            return entity;

        }

        public virtual TEntity AddOrUpdate(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity is null!");

            if (entity.ID != 0)
                return Update(entity);
            else
                return Insert(entity);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity is null!");

            entity.CreationTime = DateTime.Now;

            DbSet.Add(entity);
            Commit();

            return entity;
        }


        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity is null!");

            entity.LastUpdateTime = DateTime.Now;
            //if its ISoftUpdatable , get deep copy of entity and insert it as a soft deleted with FKPreviousVersionID=entity.ID 
            if (typeof(ISoftUpdatable).IsAssignableFrom(typeof(TEntity)))
            {
                var dbResult = _context.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.ID == (entity as ISoftUpdatable).ID);
                if (dbResult == null)
                    throw new ArgumentNullException("ISoftUpdatable object is in db null!");


                (dbResult as ISoftUpdatable).ID = 0;
                (dbResult as ISoftUpdatable).FKPreviousVersionID = (entity as ISoftUpdatable).ID;
                (dbResult as ISoftUpdatable).Deleted = true;
                (dbResult as ISoftUpdatable).LastUpdateTime = null;

                return Insert(dbResult);
            }

            Commit();
            return entity;
        }


        protected virtual void Commit()
        {
            _context.SaveChanges();
        }
        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}