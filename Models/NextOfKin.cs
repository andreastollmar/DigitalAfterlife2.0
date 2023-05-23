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
        public string? Gender { get; set; } // 3 olika kön (man, kvinna, annat)
        [Display(Name = "Födelsedatum")]
        public int BirthDate { get; set; } // 6 siffor (kolla regex lösning - xxxxxx-xxxx(6-4) eller xxxxxxxxxx(10))
        [Display(Name = "Födelsenummer")]
        public int SocialSecurity { get; set; } // 4 siffror
        [Display(Name = "Adress")]
        public string StreetAddress { get; set; }
        [Display(Name = "Postnummer")]
        public string ZipCode { get; set; }
        [Display(Name = "Stad")]
        public string City { get; set; }
        [Display(Name = "Land")]
        public string? Country { get; set; } // finns det en picker för land??
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; } // kolla regex lösning (+46 lösning?)
                                                
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string? LoginId { get; set; }


    }



}
