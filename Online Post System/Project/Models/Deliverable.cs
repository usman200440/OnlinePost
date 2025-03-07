using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINE_POST.Models
{
    public class Deliverable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliverableId { get; set; }
        public string Tracking_Number { get; set; }

        [ForeignKey("PersonalInformation")]
        public int User_id { get; set; }
        public DateTime DateOfPosting { get; set; }
        public decimal Weight { get; set; }

        [ForeignKey("service")]
        public int TypeOfDelivery { get; set; }

        [ForeignKey("payments")]
        public int pay_id { get; set; }
        public string DestinationAddress { get; set; }
        public string SenderAddress { get; set; }
        public string Contact_Number { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime DateDelivered { get; set; }
        public string package_type { get; set; }
        public string status { get; set; }

        [ForeignKey("Branch")]
        public int branch_id { get; set; }

        [ForeignKey("charges")]
        public int c_id { get; set; }
        public int Total_Price { get; set; }

        public virtual PersonalInformation PersonalInformation { get; set; }
        public virtual charge charges { get; set; }
        public virtual branch Branch { get; set; }
        public virtual servicetype service { get; set; }
        public virtual payment payments { get; set; }
    }
}
