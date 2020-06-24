using Gig_website.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gig_website.Controllers.Api
{   [Authorize]
    public class GigsController : ApiController
    {
        private  ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext(); 
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs
                .Include( g => g.Attendances.Select(a => a.Attendee))
                .Single(g => g.Id == id && g.ArtistId == userId);

            if (gig.IsCanceled)
                return NotFound();

            gig.Cancel();

            //gig.IsCanceled = true;
            

            //var notification = new Notification(NotificationType.GigCancalled, gig);
            ////{
            ////    DateTime = DateTime.Now,
            ////     Gig = gig,
            ////    Type = NotificationType.GigCancalled
            ////};

            ////var attendees = _context.Attendance 
            ////    .Where( a => a.GigId == gig.Id)
            ////    .Select(a => a.Attendee).ToList();
            


            //foreach (var attendee in gig.Attendances.Select(a => a.Attendee))
            //{
            //    attendee.Notify(notification);
            //    //var userNotification = new UserNotification
            //    //{
            //    //    User = attendee,
            //    //    Notification = notification
            //    //};
            //    //_context.UserNotifications.Add(userNotification);
            //}

            _context.SaveChanges();
            return Ok();
        }

    }
}
