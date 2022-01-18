using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorFinder.Areas.Hospital.Controllers
{
    [Area("Hospital")]
    public class HomeController : Controller
    {
        public IActionResult AddDoctorListing()
        {
            return View();
        }
        public IActionResult Doctor()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HospitalLogin()
        {
            return View();
        }
    }
}
