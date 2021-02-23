using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Action
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAction { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public byte NeedSpecialEquipment { get; set; }

        public virtual ICollection<Firefighter_Action> Firefighter_Actions { get; set; }

        public virtual ICollection<FireTruck_Action> FireTruck_Actions { get; set; }
    }
}
