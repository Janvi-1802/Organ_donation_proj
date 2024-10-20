using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Organ_donation.Models
{
    public class Doner
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Age {  get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
         [Required]
        public DateTime DOB { get; set; }
        [Required]
        public Organ donateOrgan { get; set; }

        public string BloodType { get; set; }



    }
}


namespace Organ_donation.Models
{
    public enum Gender
    {
        male, female, other
    }

    public enum Organ
    {
        Heart, Kidneys, Liver, Intestine, Lungs, Pancreas
    }
}