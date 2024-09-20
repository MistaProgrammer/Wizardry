using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizardry.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Car>? Cars { get; set; }

        public override string? ToString()
        {
            return $"{Name}, Owned cars: {Cars?.Count ?? 0}";   
        }
    }
}
