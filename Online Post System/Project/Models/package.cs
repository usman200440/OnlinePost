using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ONLINE_POST.Models
{
    public class package
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int p_id { get; set; }
        public string p_name { get; set; } = null!;
        public int p_dis { get; set; }
        public int p_price { get; set; }

    }
}
