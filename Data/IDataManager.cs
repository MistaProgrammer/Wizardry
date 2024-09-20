using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizardry.Models;

namespace Wizardry.Data
{
    public interface IDataManager
    {
        IList<Person> GetAll();
        Person? GetByID(int? id);

        void Save(Person person);
        void Edit(Person person);
        void Delete(Person person);
    }
}
