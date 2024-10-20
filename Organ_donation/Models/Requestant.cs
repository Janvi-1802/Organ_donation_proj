using System.ComponentModel.DataAnnotations;

namespace Organ_donation.Models
{
    public class Requestant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public Organ AskOrgan { get; set; }
        public string BloodType { get; set; }
    }
}
