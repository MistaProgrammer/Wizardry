using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizardry.Models;

namespace Wizardry.Data
{
    public class DataManager<TEntity> : CarsManager<TEntity> where TEntity : class
    {
        protected readonly ContextDb _db;
        protected readonly DbSet<TEntity> _dbSet;

        public DataManager(ContextDb db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _db.SaveChanges();
            }
        }

        public void Edit(TEntity entity)
        {
            if (entity != null)
            {
                _dbSet.Update(entity);
                _db.SaveChanges();
            }
        }

        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity? GetByID(int? id)
        {
            if(id != null)
            {
                return _dbSet.Find(id);
            }
            return null;
        }

        public void Save(TEntity entity)
        {
            if(entity != null)
            {
                _dbSet.Add(entity);
                _db.SaveChanges();
            }
        }
    }
}
