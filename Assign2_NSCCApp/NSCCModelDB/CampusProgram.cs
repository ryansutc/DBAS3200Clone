using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSCCModelDB
{
    //custom junction table
    public class CampusProgram
    {
       [Key]
       [Column(Order = 1)]
       [ForeignKey("Program")]
       public int ProgramId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Campus")]
        public int CampusId { get; set; }

        public Program Program { get; set; }

        public Campus Campus { get; set; }

    }
}
