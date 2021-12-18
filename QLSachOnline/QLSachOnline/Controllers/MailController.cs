
using System.Net;
using System.Net.Mail;
using System.Web.Helpers;
using System.Web.Mvc;

namespace QLSachOnline.Controllers
{
    public class MailController : Controller
    {
        [HttpPost]
        public ActionResult sendMail(string name, string body, string subject, string email)
        {

            MailAddress to = new MailAddress("huyt4242@gmail.com");
            MailAddress from = new MailAddress("huyt2603.study@gmail.com");

            MailMessage message = new MailMessage(from, to);

            message.Subject = subject;
            //message.Body = bodytext;
            message.Body = "<p><strong>Người gửi:</strong> " + name + "<br />";
            message.Body += "<p><strong>Email:</strong> " + email + "<br />";
            message.Body += "<p><strong>Nội dung:</strong><br /> " + body + "</p>";
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("huyt2603.study@gmail.com", "8464237z"),
            };
            client.Send(message);
            TempData["GuiThanhCong"] = true;
            return RedirectToAction("formGopY","Home");

        }
    }
}