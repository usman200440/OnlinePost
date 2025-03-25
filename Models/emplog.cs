using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINE_POST.Models
{
    public partial class emplog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EId { get; set; }
        public string EUserName { get; set; } = null!;
        public string EEmail { get; set; } = null!;
        public string EPassword { get; set; } = null!;

        [ForeignKey("branch")]
        public int Branch { get; set; }
        public int? ERoleId { get; set; }
        public branch branch { get; set; }
        public virtual Role? ERole { get; set; }

    }
}

