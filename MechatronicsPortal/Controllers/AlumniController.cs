using MechatronicsPortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MechatronicsPortal.Controllers
{
    public class AlumniController : Controller
    {
        MechaAlumniEntities db = new MechaAlumniEntities();

        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(string regnumber, string password)
        {
            using (var db = Util.getContext())
            {
                try
                {
                    int regNumberInt = Convert.ToInt32(regnumber);
                    if (db.AlumniUsersAuthenticates.Any(e => e.alumni_username == regNumberInt &&
                 e.almuni_password.Equals(password)))
                    {
                        AlumniUsersAuthenticate alumniUsersAuthenticate = db.AlumniUsersAuthenticates.Where(e => e.alumni_username == regNumberInt &&
                    e.almuni_password.Equals(password)).Single();
                        Session["user"] = alumniUsersAuthenticate;
                        if (alumniUsersAuthenticate.alumni_firsttime_loggedin.Equals("false"))
                        {
                            return RedirectToAction("forgotPassword", "Alumni", null);
                        }
                        else
                        {
                            return RedirectToAction("alumniSurvey");
                        }
                        
                    }
                    else
                    {
                        ViewBag.msg = "Invalid Credentials";
                        return View();
                    }
                }
                catch (FormatException e)
                {
                    ViewBag.msg = e.Message;
                    return View();
                }
            }
        }

        public ActionResult forgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult forgotPassword(string newpassword, string oldpassword)
        {
            using(var db = Util.getContext())
            {
                AlumniUsersAuthenticate alumniUsersAuthenticate = Session["user"] as AlumniUsersAuthenticate;
                if (alumniUsersAuthenticate.almuni_password.Equals(oldpassword))
                {
                    AlumniUsersAuthenticate alumni = db.AlumniUsersAuthenticates
                        .Where(e => e.alumni_username == alumniUsersAuthenticate.alumni_username).Single();

                    alumni.almuni_password = newpassword;
                    alumni.alumni_firsttime_loggedin = "true";

                    db.SaveChanges();
                    return RedirectToAction("alumniSurvey");
                }
                else
                {
                    ViewBag.msg = "Old password not valid";
                    return View();
                }
            }
        }

        public ActionResult PersonalInformation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonalInformation(string fullName, string department, int registrationNumber, string email, string contactNumber, string pecReg)
        {
            PersonalInformation pi = new PersonalInformation();
            //pi.alumni_id = 1;
            pi.full_name = fullName;
            pi.department = department;
            pi.reg_number = registrationNumber;
            pi.email = email;
            pi.contact_number = contactNumber;
            pi.pec_registration = pecReg;
            pi.alumni_id = 1;
            db.PersonalInformations.Add(pi);
            db.SaveChanges();


            return RedirectToAction("ProfessionalDetails");
        }
        public ActionResult ProfessionalDetails()
        {

            List<ProfessionalDetail> professionalDetailList = db.ProfessionalDetails.ToList();
            return View(professionalDetailList);
        }

        [HttpPost]
        public ActionResult ProfessionalDetails(String jobtitle, String companyname, String department, String worklocation,
            String worknumber, String email, String startdate, String supervisorname, String supervisoremail,
            String supervisorcontact)
        {
            ProfessionalDetail pd = new ProfessionalDetail();
            pd.job_title = jobtitle;
            pd.company_name = companyname;
            pd.department = department;
            pd.work_location = worklocation;
            pd.work_contact = worknumber;
            pd.email = email;
            pd.start_date = startdate;
            pd.supervisor_name = supervisorname;
            pd.supervisor_email = supervisoremail;
            pd.supervisor_contact = supervisorcontact;
            pd.alumni_id = 1;
            db.ProfessionalDetails.Add(pd);
            db.SaveChanges();
            List<ProfessionalDetail> professionalDetailList = db.ProfessionalDetails.ToList();
            return View(professionalDetailList);
        }


        public ActionResult EducationalDetails()
        {

            return View();
        }

        [HttpPost]
        public ActionResult EducationalDetails(String latest_qualification, String degree_title, String institute, String year_of_completion,
            String majors)
        {
            EducationalInformation educationalInformation = new EducationalInformation();
            educationalInformation.latest_qualification = latest_qualification;
            educationalInformation.degree_title = degree_title;
            educationalInformation.institute = institute;
            educationalInformation.year_of_completion = year_of_completion;
            educationalInformation.majors = majors;
            educationalInformation.alumni_id = 1;
            db.EducationalInformations.Add(educationalInformation);
            db.SaveChanges();
            return View();
        }



        public ActionResult alumniSurvey()
        {
            return View();
        }


        public ActionResult employeeInformation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult employeeInformation(String company_name, String address, String name,
            String designation, String industry)
        {
            EmployeeInformation employeeInformation = new EmployeeInformation();
            employeeInformation.company_name = company_name;
            employeeInformation.address = address;
            employeeInformation.name = name;
            employeeInformation.designation = designation;
            employeeInformation.industry = industry;
            employeeInformation.alumni_id = 1;
            db.EmployeeInformations.Add(employeeInformation);
            db.SaveChanges();
            return RedirectToAction("employeeSurvey");
        }

        public ActionResult employeeSurvey()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult saveAlumniSurveyToServer(String survey)
        {
            AlumniUsersAuthenticate alumniUsersAuthenticate = Session["user"] as AlumniUsersAuthenticate;

            using (Stream stream = Util.GenerateStreamFromString(survey))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                try
                {
                    var folder = System.Web.HttpContext.Current.Server.MapPath("~/AlumniSurveyrs/" + alumniUsersAuthenticate.alumni_username);
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                        string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/AlumniSurveyrs/" + alumniUsersAuthenticate.alumni_username),
                                                  Path.GetFileName(alumniUsersAuthenticate.alumni_name + ".pdf"));
                        System.IO.File.WriteAllBytes(path, buffer);
                    }
                    else
                    {
                        string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/AlumniSurveyrs/" + 1512232),
                                                   Path.GetFileName(alumniUsersAuthenticate.alumni_name + ".pdf"));
                        System.IO.File.WriteAllBytes(path, buffer);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return RedirectToAction("employeeInformation");
        }


    }
}