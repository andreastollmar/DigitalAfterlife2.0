using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAfterlife2._0.Models
{
    public class ServiceToDelete
    {
        public int Id { get; set; }
        public virtual Perished? Perished { get; set; }
        [ForeignKey("Perished")]
        public int PerishedId { get; set; }
        public string True { get; set; }
    }
}
