using System.ComponentModel.DataAnnotations;

namespace backend_user_registration.Models
{
    public class SocialMedia
    {
        [Key]
        [Required]
        public int id { get; set; }
        public string facebookId { get; set; }
        public string linkedinId { get; set; }
        public string twitterId { get; set; }
        public string instagramId { get; set; }
    }
}