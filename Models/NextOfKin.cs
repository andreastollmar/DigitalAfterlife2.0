using System.ComponentModel.DataAnnotations;

namespace DigitalAfterlife2._0.Models
{
    public class NextOfKin
    {
        public int Id { get; set; }
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Display(Name = "Kön")]
        public string? Gender { get; set; } 
        [Display(Name = "Födelsedatum")]
        public int BirthDate { get; set; } // 6 siffor 
        [Display(Name = "Födelsenummer")]
        public int SocialSecurity { get; set; } // 4 siffror
        [Display(Name = "Adress")]
        public string StreetAddress { get; set; }
        [Display(Name = "Postnummer")]
        public string ZipCode { get; set; }
        [Display(Name = "Stad")]
        public string City { get; set; }
        [Display(Name = "Land")]
        public string? Country { get; set; } 
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; } 
                                                
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string? LoginId { get; set; }


    }



}
