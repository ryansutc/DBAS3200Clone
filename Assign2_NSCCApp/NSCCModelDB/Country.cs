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
    [Table("Country")]
    public class Country
    {
        [Key]
        [MaxLength(2), MinLength(2)]
        [Column(TypeName = "CHAR")]
        public string CountryCode { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public string CountryName { get; set; }


        //Navigational Properties
        public virtual ICollection<ProvinceState> ProvinceStates { get; set; }

        [ForeignKey("CountryCode")]
        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
