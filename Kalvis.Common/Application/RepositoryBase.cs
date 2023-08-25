using Kalvi.Common.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Common.Application
{
    public class RepositoryBase<Tkey,TEntity> : IRepositoryBase<Tkey,TEntity> where TEntity : class
    {

        #region Constractore

        public DbContext _Context;
        public DbSet<TEntity> db;
        public RepositoryBase(DbContext Context)
        {
            _Context= Context;
            db= _Context.Set<TEntity>();
        }

        #endregion
        
        public bool Create(TEntity entity)
        {
            try
            {
                db.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
        }

        public bool CreateRange(List<TEntity> entity)
        {
            try
            {
                db.AddRange(entity);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool Exist(Expression<Func<TEntity, bool>> expression)
        {
            return db.Any(expression);
        }

        public TEntity Get(Tkey Id)
        {
            return db.Find(Id);
        }

        public List<TEntity> GetAll()
        {
            return db.ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                db.Remove(entity);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool RemoveRange(List<TEntity> entity)
        {
            try
            {
                db.RemoveRange(entity);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool SaveChanges()
        {
            try
            {
              _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
               _Context.Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
