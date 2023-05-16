using System.ComponentModel.DataAnnotations;

namespace DigitalAfterlife2._0.Models
{
    public class NextOfKin
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gender { get; set; } // 3 olika kön (man, kvinna, annat)
        public int BirthDate { get; set; } // 6 siffor (kolla regex lösning - xxxxxx-xxxx(6-4) eller xxxxxxxxxx(10))
        public int SocialSecurity { get; set; } // 4 siffror
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string? Country { get; set; } // finns det en picker för land??
        public string PhoneNumber { get; set; } // kolla regex lösning (+46 lösning?)
                                                
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string? LoginId { get; set; }


    }



}
