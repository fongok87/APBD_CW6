using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class FireTruck_Action
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFireTruck_Action { get; set; }

        
        public int IdFireTruck { get; set; }

        [ForeignKey("IdFireTruck")]
        public virtual FireTruck FireTruck { get; set; }
        
        public int IdAction { get; set; }

        [ForeignKey("IdAction")]
        public virtual Action Action { get; set; }

        [Required]
        public DateTime AssigmentDate { get; set; }
    }
}
