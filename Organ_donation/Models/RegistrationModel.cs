using System.ComponentModel.DataAnnotations;

namespace Organ_donation.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        public string Email {  get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        public string City { get; set; }

        public string country { get; set; }

        public string Phone { get; set; }

        public string address { get; set; }

        public bool AcceptUserAgreement {  get; set; }

        public string RegistrationInValid {  get; set; }




    }
}
