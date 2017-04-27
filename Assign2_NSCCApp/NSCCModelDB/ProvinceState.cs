using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSCCModelDB
{
    
    [Table("ProvinceState")]
    public class ProvinceState
    {
        [Key, Column(Order = 0, TypeName = "CHAR")]
        [MaxLength(2), MinLength(2)]
        public string ProvinceStateCode { get; set; }

        [Key, Column(Order = 1, TypeName = "CHAR")]
        [MaxLength(2), MinLength(2)]
        public string CountryCode { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Max size is 50 chars")]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

        public virtual ICollection<Applicant> Applicants { get; set; }

        [ForeignKey("CountryCode")]
        public Country Countries { get; set; } 
    }
}
