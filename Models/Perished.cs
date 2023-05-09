using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAfterlife2._0.Models
{
    public class Perished
    {
        public int Id { get; set; }
        public int SocialSecurity { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string Surname { get; set; }
        public string? Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public bool? Deathcert { get; set; }
        public bool? Fullmakt { get; set; }



        public virtual NextOfKin? NextOfKin { get; set; }
        [ForeignKey("NextOfKin")]
        public int NextOfKinId { get; set; }

    }
}
