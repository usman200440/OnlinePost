using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINE_POST.Models
{
    public partial class PersonalInformation
    {
        public int PId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[A-Z][a-z0-9]{0,49}$",
        ErrorMessage = "Username must start with an uppercase letter, followed by lowercase letters or numbers, and be between 1 and 50 characters.")]
        public string PUserName { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string PEmail { get; set; } = null!;


        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character, and must be at least 8 characters long.")]
        public string PPassword { get; set; } = null!;
        public string status { get; set; }
        public int? PRoleId { get; set; }
        public virtual Role? PRole { get; set; }
       
        public List<customer_package> customer_Packages { get; set; }
        public List<Deliverable> delivery { get; set; }
    }
}
