using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ListifyWebApp
{
    public class Logger
    {
        public static void Log(Exception exception)
        {
            StringBuilder sbExceptionMessage = new StringBuilder();
            do
            {
                sbExceptionMessage.Append("Exception Type" + Environment.NewLine);
                sbExceptionMessage.Append(exception.GetType().Name);
                sbExceptionMessage.Append(Environment.NewLine + Environment.NewLine);
                sbExceptionMessage.Append("Message" + Environment.NewLine);
                sbExceptionMessage.Append(exception.Message + Environment.NewLine + Environment.NewLine);
                sbExceptionMessage.Append("Stack Trace" + Environment.NewLine);
                sbExceptionMessage.Append(exception.StackTrace + Environment.NewLine + Environment.NewLine);

                exception = exception.InnerException;
            } while (exception != null);

            string logProvider = ConfigurationManager.AppSettings["LogProvider"];



            //if (logProvider.ToLower() == "database")
            //{
            //    //LogToDB(sbExceptionMessage.ToString());
            //}
            //else if (logProvider.ToLower() == "eventviewer")
            //{
            //    //LogToEventViewer(sbExceptionMessage.ToString());
            //}
            //else if (logProvider.ToLower() == "both")
            //{
            //   // LogToDB(sbExceptionMessage.ToString());
            //    //LogToEventViewer(sbExceptionMessage.ToString());
            //}
            //string sendEmail = ConfigurationManager.AppSettings["SendEmail"];
            //if (sendEmail.ToLower() == "true")
            //{
            //    SendEmail(sbExceptionMessage.ToString()); 
            //}
            
            
        }
        //private static void LogToEventViewer(string log)
        //{
        //    if (EventLog.SourceExists("kiran@gmail.com"))
        //    {
        //        // Create an instance of the eventlog
        //        EventLog eventLog = new EventLog("Kiran");
        //        // set the source for the eventlog
        //        eventLog.Source = "kiran@gmail.com";
        //        // Write the exception details to the event log as an error
        //        eventLog.WriteEntry(log, EventLogEntryType.Error);
        //    }
        //}

        //private static void LogToDB(string log)
        //{
        //    string cs = ConfigurationManager.ConnectionStrings["test"].ToString();
        //    SqlConnection con = new SqlConnection(cs);
        //    SqlCommand cmd = new SqlCommand("ApplicationDbContext", con);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //    SqlParameter param = new SqlParameter("@ExceptionMessage", log);
        //    cmd.Parameters.Add(param);

        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}


        public async static Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var _email = "clvaibhav444@gmail.com";           // here we are adding sender's email
                var _epass = ConfigurationManager.AppSettings["EmailPassword"]; //here we'll get our password from web.config
                var _dispName = "Vaibhav";             //add your display name to show in receiver's mail box
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(email);
                mailMessage.From = new MailAddress(_email, _dispName);
                mailMessage.Subject = subject;
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;   //we are using an html template and we want our msg to be displayed as an 
                                                 //html we set our message's IsBodyHtml value to true


                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.live.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_email, _epass);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                    await smtp.SendMailAsync(mailMessage);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }





        //public static void SendEmail(string emailBody)
        //{
        //    MailMessage mailMessage = new MailMessage("clvaibhav444@gmail.com", "clvaibhav444@gmail.com");
        //    mailMessage.Subject = "Exception";
        //    mailMessage.Body = emailBody;

        //    SmtpClient smtpClient = new SmtpClient(emailBody);
        //    smtpClient.UseDefaultCredentials = true;
        //    try
        //    {
        //        smtpClient.Send(mailMessage);
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
        //          ex.ToString());
        //    }
        //}
    }
}