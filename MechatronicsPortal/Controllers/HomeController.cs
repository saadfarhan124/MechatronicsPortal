using MechatronicsPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MechatronicsPortal.Controllers
{
    public class HomeController : Controller
    {
        MechaAlumniEntities db = new MechaAlumniEntities();
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
        public ActionResult saveSurveyToServer(String survey)
        {
            
            return RedirectToAction("employeeInformation"); 
        }
    }
}