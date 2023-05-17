using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAfterlife2._0.Models
{
    public class Perished
    {
        public int Id { get; set; }
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        public string? Gender { get; set; }
        [Display(Name = "Födelsedatum")]
        public int BirthDate { get; set; } // 6 siffror
        [Display(Name = "Sista 4")]
        public int SocialSecurity { get; set; } // 4 siffror
        [Display(Name = "Telefon nummer")]
        public string? PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public bool? Deathcert { get; set; }
        public bool? Fullmakt { get; set; }



        public virtual NextOfKin? NextOfKin { get; set; }
        [ForeignKey("NextOfKin")]
        public int NextOfKinId { get; set; }

    }
}
