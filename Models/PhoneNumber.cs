using System.ComponentModel.DataAnnotations;

namespace backend_user_registration.Models
{
    public class PhoneNumber
    {
        [Key]
        [Required]
        public String id { get; set; }

        public String label { get; set; }

        public String number { get; set; }
    }
}