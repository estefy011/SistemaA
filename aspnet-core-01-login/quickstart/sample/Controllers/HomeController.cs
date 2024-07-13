using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace SampleMvcApp.Controllers
{
    public class HomeController : Controller


    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

       
    }
}
