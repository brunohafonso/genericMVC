using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using generic.mvc.domain.contracts;
using generic.mvc.domain.contracts;
using generic.mvc.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace generic.mvc.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IBaseRepository<User> _userRepository;

        public HomeController(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }        
        public IActionResult Index()
        {
            return View(_userRepository.ListAll());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}
