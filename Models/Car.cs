using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizardry.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Display(Name = "Brand")]
        public string Brand { get; set; }
        public string Model { get; set; }
        public Fuel Fuel { get; set; }

        public int? PersonId { get; set; }
        public Person? Driver { get; set; }
    }
}
