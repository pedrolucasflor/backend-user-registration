using System.ComponentModel.DataAnnotations;

namespace backend_user_registration.Models
{
    public class PhoneNumber
    {
        [Key]
        [Required]
        public int id { get; set; }

        public string label { get; set; }

        public string number { get; set; }
    }
}