using System.ComponentModel.DataAnnotations;

namespace DigitalAfterlife2._0.Models
{
    public class NextOfKin
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        // public int SocialSecurity { get; set; }
        public string? MiddleName { get; set; }
        public string Surname { get; set; }
        public string ZipCode { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string? LoginId { get; set; }
    }
    


}
