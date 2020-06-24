using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_show.Models;
using To_show.Viewmodels;

namespace To_show.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {

            var upcomingGigs = _context.info
              
               .Where(g => g.DateTime > DateTime.Now );
          

            var viewModel = new HomeViewModel
            {
                Info = upcomingGigs,                
            };

            return View( viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}