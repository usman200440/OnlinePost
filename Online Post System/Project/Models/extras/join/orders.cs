namespace ONLINE_POST.Models.extras.join
{
    public class orders
    {
        public int DeliverableId { get; set; }
        public string Tracking_Number { get; set; }
        public DateTime DateOfPosting { get; set; }
        public decimal Weight { get; set; }
        public string DestinationAddress { get; set; }
        public string SenderAddress { get; set; }
        public string Contact_Number { get; set; }
        public string branch_name { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime DateDelivered { get; set; }
        public string package_type { get; set; }
        public int normal_charges { get; set; }
        public int service_charges { get; set; }
        public int Total_Price { get; set; }
        public string status { get; set; }
    }
}
