using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ONLINE_POST.Models
{
    public class branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int b_id { get; set; }
        public string b_name { get; set; } = null!;
        [ForeignKey("city")]
        public int c_id { get; set; }
        public City city { get; set; }

        [JsonIgnore]
        public List<EmployeeInformation> employees { get; set; }
        public List<Deliverable> deliverables { get; set; }
    }
}
