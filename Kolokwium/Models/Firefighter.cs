using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Firefighter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFirefighter { get; set; }

        [MaxLength(30)]
        [Required]
        public string Firstname { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Firefighter_Action> Firefighter_Actions { get; set; }

    }
}
