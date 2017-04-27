using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSCCModelDB
{
    [Table("Applicant")]
    public class Applicant
    {
        [Key]
        public int ApplicantId { get; set; }

        [MaxLength(9, ErrorMessage = "SIN must be 9 numbers")]
        [Column(TypeName = "VARCHAR")]
        public string SIN { get; set; }

        [MaxLength(10, ErrorMessage = "Prefix must be no more than 10 chars")]
        [Column(TypeName = "VARCHAR")]
        public string Prefix { get; set; } //error thrown when trying to set to nullable string!!!

        [Required]
        [MaxLength(50, ErrorMessage = "first Name must be no more than 50 chars")]
        [Column(TypeName = "VARCHAR")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Middle Name must be no more than 50 chars")]
        [Column(TypeName = "VARCHAR")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Last Name must be no more than 50 chars")]
        [Column(TypeName = "VARCHAR")]
        public string LastName { get; set; }

        [MaxLength(50, ErrorMessage = "must be no more than 50 chars")]
        [Column(TypeName = "VARCHAR")]
        public string FirstNamePreferred { get; set; }

        [MaxLength(50, ErrorMessage = " must be no more than 50 chars")]
        [Column(TypeName = "VARCHAR")]
        public string LastNamePrevious { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        [MaxLength(1)]
        [Column(TypeName = "VARCHAR")]
        public string Gender { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = " must be no more than 50 chars")]
        [Column(TypeName = "VARCHAR")]
        public string StreetAddress1 { get; set; }

        [MaxLength(50, ErrorMessage = " must be no more than 50 chars")]
        [Column(TypeName = "VARCHAR")]
        public string StreetAddress2 { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50, ErrorMessage = " must be no more than 50 chars")]
        public string City { get; set; }
        
        [MaxLength(50, ErrorMessage = " must be no more than 50 chars")]
        [Column(TypeName = "VARCHAR")]
        public string County { get; set; }

        [MaxLength(2, ErrorMessage = " must be no more than 50 chars")]
        [Column(TypeName = "CHAR")]
        public string ProvinceStateCode { get; set; }

        [MaxLength(50, ErrorMessage = " must be no more than 50 chars")]
        [Column(TypeName = "VARCHAR")]
        public string ProvinceStateOther { get; set; }

        //Foreign Key
       // [ForeignKey("Country")]
        [MaxLength(2), MinLength(2)]
        [Column(TypeName = "CHAR")]
        public string CountryCode { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(25, ErrorMessage = " must be no more than 25 chars"), MinLength(10)]
        public string PhoneHome { get; set; }

        [MaxLength(25, ErrorMessage = " must be no more than 25 chars"), MinLength(10)]
        [Column(TypeName = "VARCHAR")]
        public string PhoneWork { get; set; }

        [MaxLength(25, ErrorMessage = " must be no more than 25 chars"), MinLength(10)]
        [Column(TypeName = "VARCHAR")]
        public string PhoneCell { get; set; }

        //further validation required
        [Required]
        [MaxLength(50, ErrorMessage = " must be no more than 50 chars and at least 5 chars"), MinLength(5)]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }

        //foreign key
        [Required]
        //[ForeignKey("Citizenship")]
        public int Citizenship { get; set; }

        //foreign key (not required)
        //[ForeignKey("Country")]
        [StringLength(2)]
        [Column(TypeName = "CHAR")]
        public string CitizenshipOther { get; set; }

        public bool HasCriminalConviction { get; set; }

        public bool OnChildAbuseRegistry { get; set; }

        public bool HasDisciplinaryAction { get; set; }

        public bool IsAfricanCanadian { get; set; }

        public bool IsFirstNations { get; set; }

        public bool IsCurrentALP { get; set; }

        public bool HasDisability { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50, ErrorMessage = " must be no more than 50 chars and at least 6 chars"), MinLength(6)]
        public string Password { get; set;  }



        //navigational fields (relationships)
        public virtual ICollection<Application> Applications { get; set; }

        [ForeignKey("CountryCode")]
        public Country Country { get; set; }

        [ForeignKey("CitizenshipOther")]
        public Country CitizenshipOtherCountry { get; set; }

        public ProvinceState ProvinceState { get; set; }

        [ForeignKey("Citizenship")]
        public Citizenship ApplicantCitizenship { get; set; }


    }
}
