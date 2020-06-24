using Gig_website.Models;
using Gig_website.viewmodel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gig_website.Controllers
{
    public class GigsController : Controller

    {
        private readonly ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Myupcoming()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Gigs.Where(g => g.ArtistId == userId && g.DateTime > DateTime.Now && !g.IsCanceled)
                .Include(g => g.Genre)
                .ToList();
            return View(gigs);

        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Attendance
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();

            var viewModel = new HomeViewModel
            {
                UpcomingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm Attending"

            };

            return View("Gigs", viewModel);
        }
        [HttpPost]
        public ActionResult Search(HomeViewModel viewmodel)
        {
            return RedirectToAction("Index", "Home", new { query = viewmodel.SearchTerm });
        }


        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormviewmodel
            {
                Genres = _context.Genres.ToList(),
                Heading = "Add a gig"

            };



            return View("GigForm", viewModel);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);
            var viewModel = new GigFormviewmodel
            {
                Heading = "Edit a Gig",
                Id = gig.Id,
                Genres = _context.Genres.ToList(),
                Date = gig.DateTime.ToString("d MMM yyyy"),
                Time = gig.DateTime.ToString("HH:mm"),
                Genre = gig.GenreId,
                Venue = gig.Venue

            };
            return View("GigForm", viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormviewmodel ViewModel)
        {
            //var artistId = User.Identity.GetUserId();
            //var artist = _context.Users.Single(u => u.Id == artistId);
            //var genre = _context.Genres.Single(g => g.Id == ViewModel.Genre);
            if (!ModelState.IsValid)
            {
                ViewModel.Genres = _context.Genres.ToList();
                return View("GigForm", ViewModel);
            }

            var gig = new Gig
            {
                //ArtistId = artistId,            
                // DateTime = DateTime.Parse(string.Format("{0} {1}", ViewModel.Date, ViewModel.Time)),

                ArtistId = User.Identity.GetUserId(),
                DateTime = ViewModel.GetDateTime(),
                GenreId = ViewModel.Genre,
                Venue = ViewModel.Venue

            };
            gig.Create();

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Myupcoming", "Gigs");

        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormviewmodel ViewModel)
        {
            //var artistId = User.Identity.GetUserId();
            //var artist = _context.Users.Single(u => u.Id == artistId);
            //var genre = _context.Genres.Single(g => g.Id == ViewModel.Genre);
            if (!ModelState.IsValid)
            {
                ViewModel.Genres = _context.Genres.ToList();
                return View("GigForm", ViewModel);
            } 
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .Single(g => g.Id == ViewModel.Id && g.ArtistId==userId );
            //gig.Venue = ViewModel.Venue;
            //gig.DateTime = ViewModel.GetDateTime();   
            //gig.GenreId = ViewModel.Genre;

            gig.Modify(ViewModel.GetDateTime(), ViewModel.Venue, ViewModel.Genre);


            _context.SaveChanges();



            return RedirectToAction("Myupcoming", "Gigs");

        }
    }
}