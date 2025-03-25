using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINE_POST.Models
{
    public class customer_package
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int c_id { get; set; }
        [ForeignKey("PersonalInformation")]
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string package_name { get; set; }
        public int package_discount { get; set; }
        public int package_price { get; set; }
        public DateTime expired { get; set; }

        public virtual PersonalInformation PersonalInformation { get; set; }
    }
}
