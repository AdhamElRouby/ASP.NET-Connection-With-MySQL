using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Model
{
    public class Startup
    {
        [Key]
        public int StartupID { get; set; }
        [MaxLength(50), Required]
        public string StartupName { get; set; }
        [MaxLength(50), Required]
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        // add a one-to-many relationship with Participants
        public ICollection<Participant> Participants { get; set; }
    }
}