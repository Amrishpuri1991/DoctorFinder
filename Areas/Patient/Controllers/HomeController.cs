using DoctorFinder.EDM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorFinder.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class HomeController : Controller
    {
        private DoctorFinderDBContext dc = null;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly ISessionManage sessionManage;

        public HomeController(DoctorFinderDBContext _dc, ISessionManage _sessionManage)
        {
            dc = _dc;
            sessionManage = _sessionManage;
        }

        public IActionResult Index()
        {
            ViewBag.Session = sessionManage.GetSession();
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.Session = sessionManage.GetSession();
            return View();
        }

        [HttpPost]
        public string Login(string AdminEmail, string AdminPassword)
        {
            //check admin detail from db
            var adminOBJ = dc.TblAdmins
                            .Where(b => b.AdminEmail == AdminEmail && b.AdminPassword == AdminPassword)
                            .FirstOrDefault();

            if (adminOBJ != null)
            {
                sessionManage.SetSession(adminOBJ);
                return "1";

            }

            return "0";
        }

        public IActionResult Register()
        {
            ViewBag.Session = sessionManage.GetSession();
            return View();
        }

        [HttpPost]
        public IActionResult Register(TblAdmin admin)
        {
            // first add entry in admin table as patient
            admin.AdminRole = "Patient";
            dc.TblAdmins.Add(admin);
            dc.SaveChanges();

            ///then create entry for patient table
            var newPatient = new TblPatient
            {
                PatientName = admin.AdminFname,
                PatientEmail = admin.AdminEmail
            };

            dc.TblPatients.Add(newPatient);
            dc.SaveChanges();
            return View();
        }



        public IActionResult Logout()
        {

            sessionManage.KillSession();
            return RedirectToAction("Index");
        }

        public IActionResult MyProfile(string name)
        {
            ViewBag.Session = sessionManage.GetSession();

            var result = dc.TblPatients.Find(name);

            return View();
        }

    }
}
