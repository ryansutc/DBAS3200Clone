using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSCCModelDB
{
    [Table("AcademicYear")]
    public class AcademicYear
    {
        //fields
        public int AcademicYearId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Description must be 50 characters or less")]
        [Column(TypeName = "VARCHAR")]
        public string Description { get; set; } 
                
        //relationship fields
        //public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
