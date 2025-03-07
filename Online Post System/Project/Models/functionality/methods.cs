using Newtonsoft.Json;

namespace ONLINE_POST.Models.functionality
{
    public class methods
    {
        post_management_systemContext db = new post_management_systemContext();
        public string body_data(IHttpContextAccessor httpContextAccessor)
        {
            IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
            var data = _httpContextAccessor.HttpContext.Session.GetString("delivery");
            var deliveryData = JsonConvert.DeserializeObject<Deliverable>(data);
            var b = db.branches.Where(x => x.b_id == deliveryData.branch_id).FirstOrDefault();
            var p = db.payments.Where(x => x.p_id == deliveryData.pay_id).FirstOrDefault();
            var s = db.servicetypes.Where(x => x.s_id == deliveryData.TypeOfDelivery).FirstOrDefault();
            if (deliveryData == null)
            {
                // Handle the case where the object is not found in the session
                return "Object not found in session";
            }

            var body = $@"
    <html>
    <head>
        <style>
            .delivery-info {{
                border: 2px groove white;
                box-shadow: 0px 0px 3px black, inset 0px 0px 2px 2px black; 
                padding: 20px;
                margin: auto;
                width: 50%;
            }}
            body {{
                font-family: 'Arial', sans-serif;
                line-height: 1.6;
            }}
            h2 {{
                color: #007BFF;
            }}
            p {{
                margin-bottom: 10px;
            }}
            strong {{
                font-weight: bold;
            }}
        </style>
    </head>
    <body>
        <div class='delivery-info'>
            <h2>PostTech Delivery Information</h2>
            <p><strong>Tracking Number:</strong> {deliveryData.Tracking_Number}</p>
            <p><strong>Date of Posting:</strong> {deliveryData.DateOfPosting}</p>
            <p><strong>Weight:</strong> {deliveryData.Weight}</p>
            <p><strong>Type of Delivery:</strong> {s.service_name}</p>
            <p><strong>Payment Type:</strong> {p.p_name}</p>
            <p><strong>Destination Address:</strong> {deliveryData.DestinationAddress}</p>
            <p><strong>Sender Address:</strong> {deliveryData.SenderAddress}</p>
            <p><strong>Contact Number:</strong> {deliveryData.Contact_Number}</p>
            <p><strong>Package Type:</strong> {deliveryData.package_type}</p>
            <p><strong>Branch Name:</strong> {b.b_name}</p>
            <p><strong>Total Price:</strong> {deliveryData.Total_Price} $</p>
        </div>
    </body>
    </html>
";

            return body;
        }

    }
}
