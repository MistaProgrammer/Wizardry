using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizardry.Models;

namespace Wizardry.Data
{
    public interface CarsManager<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity? GetByID(int? id);

        void Save(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
    }
}
