using Microsoft.AspNetCore.Identity;

namespace Organ_donation.Models
{
    public class User:IdentityUser
    {
        public string firstName {  get; set; }

        public string lastName { get; set; }

        public string City { get; set; }

        public string country { get; set; }

        public string Phone { get; set; }

        public string address {  get; set; }

    }
}
