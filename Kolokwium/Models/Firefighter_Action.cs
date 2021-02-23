using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Firefighter_Action
    {

        public int IdFirefighter { get; set; }

        public int IdAction { get; set; }


        [ForeignKey("IdFirefighter")]
        public virtual Firefighter Firefighter { get; set; }

        [ForeignKey("IdAction")]
        public virtual Action Action { get; set; }
    }
}
