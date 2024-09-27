using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizardry.Models;

namespace Wizardry.Data
{
    public class CarsManager : DataManager<Car>, ICarsManager
    {
        public CarsManager(ContextDb db) : base(db)
        {
        }
    }
}
