using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ONLINE_POST.Models
{
    public class servicetype
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int s_id { get; set; }
        public string service_name { get; set; }
        public int service_charges { get; set; }

        public List<Deliverable> deliverables { get; set; }
    }
}
