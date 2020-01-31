using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MechatronicsPortal.Controllers;
using System.Configuration;
using System.Net;

namespace MechatronicsPortal.Controllers
{
    public class ProgramManagerController : Controller
    {
      
        // GET: ProgramManager
        public ActionResult ViewStudents()
        {
            if(TempData["message"] != null)
            {
                ViewBag.message = TempData["message"].ToString();
            }
            
            return View(Util.getContext().AlumniUsersAuthenticates.ToList());
        }

        public ActionResult SendEmail(string email)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["smtp"].ToString(), Convert.ToInt32(ConfigurationManager.AppSettings["portnumber"]));
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);
            mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["username"].ToString());
            mailMessage.To.Add(email);
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "";
            smtp.Send(mailMessage);
            TempData["message"] = "Email Sent";
            return RedirectToAction("ViewStudents");
        }
    }
}