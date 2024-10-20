namespace Organ_donation.Models
{
    public class DonerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public Organ Organ { get; set; } // Enum property
        public string BloodType { get; set; } // BloodType property
        public bool IsMatch { get; set; } // Whether the donor is a match


       
    }
}
