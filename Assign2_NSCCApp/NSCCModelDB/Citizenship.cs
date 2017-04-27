using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NSCCModelDB
{
    [Table("Citizenship")]
    public class Citizenship
    {
        [Key]
        public int CitizenshipId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        //navigational fields (relationships)
        //public virtual ICollection<Applicant> Applicant { get; set; }
    }
}
