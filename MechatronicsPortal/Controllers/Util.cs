using MechatronicsPortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MechatronicsPortal.Controllers
{
    public class Util
    {
        public static MechaAlumniEntities getContext()
        {
            return new MechaAlumniEntities();
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static void sendEmailToEmployeer(string email, string alumniID)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["smtp"].ToString(), Convert.ToInt32(ConfigurationManager.AppSettings["portnumber"]));
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);
            smtp.Port = 587;
            mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["username"].ToString());
            mailMessage.To.Add(email);
            mailMessage.IsBodyHtml = true;
            string surveyInviteUrl = $"http://localhost:49961/Alumni/employeeInformation?alumniID={alumniID}";
            mailMessage.Body = "Please fill out the survey at \n";
            mailMessage.Body += surveyInviteUrl;
            smtp.Send(mailMessage);
        }

    }
}