using System;
using System.Collections.Generic;

namespace ONLINE_POST.Models
{
    public partial class Role
    {
        public Role()
        {
            EmployeeInformations = new HashSet<EmployeeInformation>();
            PersonalInformations = new HashSet<PersonalInformation>();
        }

        public int RId { get; set; }
        public string RName { get; set; } = null!;

        public virtual ICollection<EmployeeInformation> EmployeeInformations { get; set; }
        public virtual ICollection<PersonalInformation> PersonalInformations { get; set; }
    }
}
