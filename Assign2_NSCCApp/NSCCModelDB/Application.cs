using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSCCModelDB
{
    [Table("Application")]
    public class Application
    {

        //fields
        [Key]
        public int ApplicationId { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        public int ApplicantId { get; set; }

        public int ApplicationFee { get; set; }

        public bool Paid { get; set; }

        //navigational fields (relationships)
        //public virtual ICollection<AcademicYear> AcademicYears { get; set; }

        public virtual ICollection<ProgramChoice> ProgramChoices { get; set; }

        public virtual ICollection<AcademicYear> AcademicYears { get; set; }


    }
}
