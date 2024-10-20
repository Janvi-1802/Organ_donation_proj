using System.ComponentModel.DataAnnotations;

namespace Organ_donation.Models
{
    public class CustomLoginModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public string LoginInValid { get; set; }

        public string LoginFailedMessage { get; set; }
    }
}
