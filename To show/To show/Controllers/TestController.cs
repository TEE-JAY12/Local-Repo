using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_show.Models;
using To_show.Viewmodels;

namespace To_show.Controllers
{
    public class TestController : Controller
    {

        private readonly ApplicationDbContext _context;
        public TestController()
        {
            _context = new ApplicationDbContext();

        }

        // GET: Test
        public ActionResult display(infoformviewmodel Viewmodel)
        {
            if (!ModelState.IsValid)
            {

                return View("display", Viewmodel);
            }
            Viewmodel.Heading = "Add an information";
            var gig = new Information
            {
               
                Name = Viewmodel.Name,
                DateTime = Viewmodel.GetDateTime(),
                Sex = Viewmodel.Sex

            };
            _context.info.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {

            var gig = _context.info.Single(g => g.Id == id);
            var viewModel = new infoformviewmodel
            {
                Heading = "Update an info",
                Id = gig.Id,
                Name =gig.Name,
                Date = gig.DateTime.ToString("d MMM yyyy"),
                Time = gig.DateTime.ToString("HH:mm"),
                Sex = gig.Sex


            };
            return View("display", viewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(infoformviewmodel Viewmodel)
        {

            if (!ModelState.IsValid)
            {

                return View("display", Viewmodel);
            }
            
            var gig = _context.info
                .Single(g => g.Id == Viewmodel.Id ); 
            gig.Name = Viewmodel.Name;
            gig.Sex = Viewmodel.Sex;
            gig.DateTime = Viewmodel.GetDateTime();




            _context.SaveChanges();



            return RedirectToAction("Index", "Home");

        }



    }
    }
