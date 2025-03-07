using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ONLINE_POST.Models.extras
{
    public class form
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int f_id { get; set; }
        public string f_name { get; set; } = null!;
        public string status { get; set; } = null!;

    }
}
