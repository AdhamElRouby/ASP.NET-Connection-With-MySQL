using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Model
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string FirstName { get; set; }
        [MaxLength(50), Required]
        public string LastName { get; set; }
        [MaxLength(11), Required]
        public string PhoneNumber { get; set; }
        [MaxLength(50), Required]
        public string Email { get; set; }
        [ForeignKey("Startup")]
        public int StartupID { get; set; }
        public Startup Startup { get; set; }  
    }
}