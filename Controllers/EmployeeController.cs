using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NPOI.XWPF.UserModel;
using ONLINE_POST.Models;
using ONLINE_POST.Models.extras.join;
using ONLINE_POST.Models.filters;
using ONLINE_POST.Models.functionality;

namespace ONLINE_POST.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    [TypeFilter(typeof(empAuthenticationFilter))]
    public class EmployeeController : Controller
    {
        post_management_systemContext db = new post_management_systemContext();
        public IActionResult Index()
        {
            var pending = db.Delivery_Histories.Where(x=>x.status=="Pending").Count();
            TempData["pending"] = pending;
            var onway = db.Delivery_Histories.Where(x => x.status == "On_the_Way").Count();
            TempData["onway"] = onway;
            var Completed = db.Delivery_Histories.Where(x => x.status == "Completed").Count();
            TempData["completed"] = Completed;
            var overall = db.Delivery_Histories.Count();
            TempData["overall"] = overall;

            var emp = HttpContext.Session.GetString("Emp");
            var emp_data = JsonConvert.DeserializeObject<EmployeeInformation>(emp);
            var employee = db.EmployeeInformations.Where(x => x.EId==emp_data.EId).FirstOrDefault();
            var branch = db.branches.Where(x => x.b_id==employee.Branch).FirstOrDefault();
            TempData["emp"] = employee;
            TempData["branch"] = branch;
            return View();
        }

       

        public IActionResult pending_delivery()
        {
            var pending = order_list("Pending");
            return View(pending);
        }

        [HttpPost]
        public IActionResult pending_delivery(string status, int id)
        {
            var delivery = db.Deliverables.Where(x => x.DeliverableId == id).FirstOrDefault();
            var d_history = db.Delivery_Histories.Where(x => x.DeliverableId == id).FirstOrDefault();
            var user = db.PersonalInformations.Where(x => x.PId == delivery.User_id).FirstOrDefault();
            if (status == "On_the_Way")
            {
                delivery.status = status;
                d_history.status = status;
                db.SaveChanges();
                var body = "Your order is currently in the process of being picked up." +
                    " It will be delivered from the sender's address to the destination address." +
                    " Please note that this order cannot be deleted.";
                verifyemail mail = new verifyemail(user.PEmail, body, "Online Post Delivery Msg");
                SetCookie("success-msg", "Delivery " + status + " Successfully");
                return RedirectToAction("pending_delivery", "Employee");
            }
            else
            {
                db.Deliverables.Remove(delivery);
                db.Delivery_Histories.Remove(d_history);
                db.SaveChanges();
                SetCookie("success-msg", "Delivery Deleted Successfully");
                return RedirectToAction("pending_delivery", "Employee");
            }

        }

        public IActionResult onway_delivery()
        {
            var onway = order_list("On_the_Way");
            return View(onway);
        }
        [HttpPost]
        public IActionResult onway_delivery(string status, int id)
        {
            var delivery = db.Deliverables.Where(x => x.DeliverableId == id).FirstOrDefault();
            var d_history = db.Delivery_Histories.Where(x => x.DeliverableId == id).FirstOrDefault();
            var user = db.PersonalInformations.Where(x => x.PId == delivery.User_id).FirstOrDefault();
            if (status == "Completed")
            {
                delivery.DateDelivered = DateTime.Now;
                d_history.DateDelivered = DateTime.Now;
                delivery.status = status;
                d_history.status = status;
                db.SaveChanges();
                var body = "<div style='font-family: Arial, sans-serif; font-size: 16px; color: #333; line-height: 1.6; margin-bottom: 20px;'>\r\n    <p style='margin: 0 0 10px;'>\r\n" +
                    "Your order has been successfully completed.\r\n</p>\r\n" +
                    "<p style=\"margin: 0; font-weight: bold;\">\r\n Please note that this order cannot be deleted.\r\n  </p>\r\n</div>";

                verifyemail mail = new verifyemail(user.PEmail, body, "Online Post Delivery Msg");
                SetCookie("success-msg", "Delivery " + status + " Successfully");
            }
            else
            {

            }
            return RedirectToAction("onway_delivery", "Employee");
        }

        public IActionResult completed_delivery()
        {
            var complete = completeorder("Completed");
            return View(complete);
        }
        public IActionResult view_details(int id)
        {
            if (id != null)
            {
                var details = orders("Completed",id);
                return View(details);
            }
            else
            {
                return RedirectToAction("completed_delivery","Employee");
            }
            
        }

        public IActionResult delivery_list()
        {
            var order = fullorder();
            return View(order);
        }

        public List<orders> order_list(string status)
        {
            var emp = HttpContext.Session.GetString("Emp");
            var emp_data = JsonConvert.DeserializeObject<EmployeeInformation>(emp);
            var orders = db.Deliverables.Where(x => x.branch_id == emp_data.Branch && x.status==status).Include(x => x.service).Include(x => x.charges).Select(y => new orders
            {

                DeliverableId = y.DeliverableId,
                Tracking_Number = y.Tracking_Number,
                DateOfPosting = y.DateOfPosting,
                Weight = y.Weight,
                DestinationAddress = y.DestinationAddress,
                SenderAddress = y.SenderAddress,
                Contact_Number = y.Contact_Number,
                DateReceived = y.DateReceived,
                DateDelivered = y.DateDelivered,
                package_type = y.package_type,
                normal_charges = y.charges.c_rate,
                service_charges = y.service.service_charges,
                Total_Price = y.Total_Price,
                status = y.status

            }).ToList();

            return orders;
        }

        public orders orders(string status,int id)
        {
            var orders = db.Delivery_Histories.Where(x => x.status == status && x.DeliverableId == id).Select(y => new orders
            {

                DeliverableId = y.DeliverableId,
                Tracking_Number = y.Tracking_Number,
                DateOfPosting = y.DateOfPosting,
                Weight = y.Weight,
                DestinationAddress = y.DestinationAddress,
                SenderAddress = y.SenderAddress,
                Contact_Number = y.Contact_Number,
                DateReceived = y.DateReceived,
                DateDelivered = y.DateDelivered,
                package_type = y.package_type,
                normal_charges = y.normal_charges,
                service_charges = y.service_charges,
                Total_Price = y.Total_Price,
                status = y.status,
                branch_name=y.branch_name

            }).FirstOrDefault();

            return orders;
        }


        public List<orders> fullorder()
        {
            var emp = HttpContext.Session.GetString("Emp");
            var emp_data = JsonConvert.DeserializeObject<EmployeeInformation>(emp);
            var branch = db.branches.Where(x => x.b_id == emp_data.Branch).FirstOrDefault();
            var orders = db.Delivery_Histories.Where(x => x.branch_name == branch.b_name).Select(y => new orders
            {

                DeliverableId = y.DeliverableId,
                Tracking_Number = y.Tracking_Number,
                DateOfPosting = y.DateOfPosting,
                Weight = y.Weight,
                DestinationAddress = y.DestinationAddress,
                SenderAddress = y.SenderAddress,
                Contact_Number = y.Contact_Number,
                DateReceived = y.DateReceived,
                DateDelivered = y.DateDelivered,
                package_type = y.package_type,
                normal_charges = y.normal_charges,
                service_charges = y.service_charges,
                Total_Price = y.Total_Price,
                status = y.status,
                branch_name = y.branch_name

            }).ToList();

            return orders;
        }

        public List<orders> completeorder(string status)
        {
            var emp = HttpContext.Session.GetString("Emp");
            var emp_data = JsonConvert.DeserializeObject<EmployeeInformation>(emp);
            var branch = db.branches.Where(x => x.b_id == emp_data.Branch).FirstOrDefault();
            var orders = db.Delivery_Histories.Where(x => x.branch_name == branch.b_name && x.status==status).Select(y => new orders
            {

                DeliverableId = y.DeliverableId,
                Tracking_Number = y.Tracking_Number,
                DateOfPosting = y.DateOfPosting,
                Weight = y.Weight,
                DestinationAddress = y.DestinationAddress,
                SenderAddress = y.SenderAddress,
                Contact_Number = y.Contact_Number,
                DateReceived = y.DateReceived,
                DateDelivered = y.DateDelivered,
                package_type = y.package_type,
                normal_charges = y.normal_charges,
                service_charges = y.service_charges,
                Total_Price = y.Total_Price,
                status = y.status,
                branch_name = y.branch_name

            }).ToList();

            return orders;
        }

        //word file

        public IActionResult GenerateWordDocument(int id)
        {
            // Fetch data from the database
            var order = db.Deliverables
                .Where(x => x.DeliverableId == id)
                .Include(x => x.service)
                .Include(x => x.charges)
                .FirstOrDefault();

            // Create a new Word document
            var doc = new XWPFDocument();

            // Create a paragraph for the heading
            var headingParagraph = doc.CreateParagraph();
            headingParagraph.Alignment = ParagraphAlignment.CENTER;
            var headingRun = headingParagraph.CreateRun();
            headingRun.SetText("Post Tech Order Details");
            headingRun.FontSize = 20;
            headingRun.IsBold = true;

            // Add a line break
            doc.CreateParagraph();

            FillTable(doc, order);

            return File(WriteToStream(doc), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "YourDocument.docx");
        }

        private byte[] WriteToStream(XWPFDocument document)
        {
            using (var stream = new MemoryStream())
            {
                document.Write(stream);
                return stream.ToArray();
            }
        }


        public void FillTable(XWPFDocument doc, Deliverable order)
        {


            var table = doc.CreateTable(13, 2);

            
          

            FillRow(table, 0, "Tracking Number", order.Tracking_Number);
            FillRow(table, 1, "User Id", order.User_id.ToString());
            FillRow(table, 2, "Date of Posting", order.DateOfPosting.ToShortDateString());
            FillRow(table, 3, "Weight", order.Weight.ToString());
            FillRow(table, 4, "Type of Delivery", order.TypeOfDelivery.ToString());
            FillRow(table, 5, "Payment Id", order.pay_id.ToString());
            FillRow(table, 6, "Destination Address", order.DestinationAddress);
            FillRow(table, 7, "Sender Address", order.SenderAddress);
            FillRow(table, 8, "Contact Number", order.Contact_Number);
            FillRow(table, 9, "Date Received", order.DateReceived.ToShortDateString());
            FillRow(table, 10, "Date Delivered", order.DateDelivered.ToShortDateString());
            FillRow(table, 11, "Package Type", order.package_type);
            FillRow(table, 12, "Status", order.status);
        }

        public void FillRow(XWPFTable table, int rowIndex, string cell1, string cell2)
        {
            var row = table.GetRow(rowIndex);
            row.GetCell(0).SetText(cell1);
            row.GetCell(1).SetText(cell2);
        }

        private void SetCookie(string cookieName, string cookieValue)
        {
            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddSeconds(3) // Expires in 3 seconds
            };
            HttpContext.Response.Cookies.Append(cookieName, cookieValue, option);
        }

    }
}




