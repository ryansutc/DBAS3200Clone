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
    [Table("Program")]
    public class Program
    {
        public Program()
        {
            //this.Campuses = new List<Campus>();
        }

        [Key]
        public int ProgramId { get; set; }

        [MaxLength(85, ErrorMessage = "Name must be 85 characters or less")]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

        //Campus (1)-->M | CampusProgram | M<-- (1)Program Custom Junction table mapping
        //navigational fields (relationships)
        //public virtual ICollection<CampusProgram> CampusProgram { get; set; }

        public virtual ICollection<Campus> Campuses { get; set; }
        
        public virtual ICollection<ProgramChoice> ProgramChoices { get; set; }
    }
}
