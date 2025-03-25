using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ONLINE_POST.Models
{
    public class charge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int c_id { get; set; }
        public int min_weight { get; set; }
        public int max_weight { get; set; }
        public int c_rate { get; set; }
        public List<Deliverable> deliverables { get; set; }
    }
}
