using System.ComponentModel.DataAnnotations;

namespace backend_user_registration.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int id { get; set; }

        public string name { get; set; }

        public string label { get; set; }
    }
}