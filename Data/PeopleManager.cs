using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizardry.Models;

namespace Wizardry.Data
{
    public class PeopleManager : DataManager<Person>, IPeopleManager
    {
        public PeopleManager(ContextDb db) : base(db)
        {
        }
    }
}
