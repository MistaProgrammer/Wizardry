using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizardry.Models;

namespace Wizardry.Data
{
    public class DataManager : IDataManager
    {
        private readonly ContextDb _db;

        public DataManager(ContextDb db)
        {
            _db = db;
        }

        public void Delete(Person person)
        {
            if (person != null)
            {
                _db.Remove(person);
                _db.SaveChanges();
            }
        }

        public void Edit(Person person)
        {
            if (person != null)
            {
                _db.Update(person);
                _db.SaveChanges();
            }
        }

        public IList<Person> GetAll()
        {
            return _db.People.ToList();
        }

        public Person? GetByID(int? id)
        {
            if(id != null)
            {
                return _db.People.Include(a => a.Cars).FirstOrDefault(a => a.Id == id);
            }
            return null;
        }

        public void Save(Person person)
        {
            if(person != null)
            {
                _db.Add(person);
                _db.SaveChanges();
            }
        }
    }
}
