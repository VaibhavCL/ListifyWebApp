using ListifyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ListifyWebApp.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ResetPasswordViewModel model)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            var fromAddress = new MailAddress("clvaibhav444@gmail.com");
            var fromPassword = "xxxxxx";
            var toAddress = new MailAddress("clvaibhav444@gmail.com");

            string subject = "subject";
            string body = "body";

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })


                smtp.Send(message);

            //mail.From = new MailAddress("clvaibhav444@gmail.com");
            //mail.To.Add("kiran@gmail.com");
            //mail.Subject = "Test Mail";
            //mail.Body = "This is for testing SMTP mail from GMAIL";

            //SmtpServer.Port = 587;
            //SmtpServer.Credentials = new NetworkCredential("clvaibhav444@gmail.com", "Abc@123");
            //SmtpServer.EnableSsl = true;
            //SmtpServer.UseDefaultCredentials = true;
            //SmtpServer.Send(mail);
            return View();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("clvaibhav444@gmail.com");
                mail.To.Add("clvaibhav444@gmail.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("username", "password");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Response.Write("Email sent");

            }
            catch (Exception ex)
            {
                Response.Write("Could not send the e-mail - error: " + ex.Message);
            }
        }
    }
}