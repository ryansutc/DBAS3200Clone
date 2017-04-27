using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSCCModelDB
{
    [Table("Campus")]
    public class Campus
    {
        public Campus()
        {
            //this.Programs = new List<Program>();
        }

        //fields
        [Key]
        public int CampusId { get; set; }

        [MaxLength(50, ErrorMessage = "Name must be 50 characters or less")]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }


        //Campus (1)-->M | CampusProgram | M<-- (1)Program Custom Junction table mapping
        //navigational fields (relationships)
        //public virtual ICollection<CampusProgram> CampusProgram { get; set; }
        public virtual ICollection<Program> Programs { get; set; }

        public virtual ICollection<ProgramChoice> ProgramChoices { get; set; }
        //navigational fields (relationships)
        //public virtual ICollection<Program> Programs { get; set; }
    }
}
