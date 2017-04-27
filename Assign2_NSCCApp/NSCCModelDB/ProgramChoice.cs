using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSCCModelDB
{
    [Table("ProgramChoice")]
    public class ProgramChoice
    {
        //fields
        [Key]
        public int ProgramChoiceId { get; set; }

        [Required]
        public int ApplicationId { get; set; }

        [Required]
        [ForeignKey("Program")]
        public int ProgramId { get; set; }

        [Required]
        [ForeignKey("Campus")]
        public int CampusId { get; set; }

        [Required]
        public int Preference { get; set; }

        public Application Application { get; set; }

        public virtual Program Program { get; set; }

        public virtual Campus Campus { get; set; }

    }
}
