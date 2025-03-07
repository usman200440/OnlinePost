using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINE_POST.Models
{
    public class payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int p_id { get; set; }
        public string p_name { get; set; }

        public List<Deliverable> deliverables { get; set; }
    }
}
