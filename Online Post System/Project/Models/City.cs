using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ONLINE_POST.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int c_id { get; set; }
        public string c_name { get; set; } = null!;
        public List<branch> branches { get; set; }

    }
}
