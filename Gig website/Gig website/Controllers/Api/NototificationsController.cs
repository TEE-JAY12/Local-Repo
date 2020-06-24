using Gig_website.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gig_website.Controllers.Api
{
    [Authorize]
    public class NototificationsController : ApiController
    {
        private ApplicationDbContext _context ;

        public NototificationsController()
        {
            _context = new ApplicationDbContext();
        }

       
        public IEnumerable<NotificationDTO> GetNewNotifcations()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _context.UserNotifications
               .Where(un => un.UserId == userId && !un.ISRead)
               .Select(un => un.Notification)
               .Include(n => n.Gig.Artist);




            return notifications.Select(n => new NotificationDTO()
            {
                DateTime = n.DateTime,
                Gig = new GigDto
                {
                    Artist = new UserDto
                    {
                        Id = n.Gig.Artist.Id,
                        Name = n.Gig.Artist.Name

                    },
                    DateTime = n.Gig.DateTime,
                    Id = n.Gig.Id,
                    IsCanceled = n.Gig.IsCanceled,
                    Venue = n.Gig.Venue
                },
                OriginalDateTime = n.OriginalDateTime,
                OriginalVenue = n.OriginalVenue,
                Type = n.Type

            });


        }
        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _context.UserNotifications
               .Where(un => un.UserId == userId && !un.ISRead)
               .ToList();
            notifications.ForEach(n => n.Read());
            _context.SaveChanges();

            return Ok();
        }


        //public IEnumerable<Notification> Todisplay()
        //{
        //    var userId = User.Identity.GetUserId();

        //    var notifications = _context.UserNotifications
        //       .Where(un => un.UserId == userId && un.ISRead)
        //       .Select(un => un.Notification)
        //       .Include(n => n.Gig.Artist);


        //    return notifications;





        //}
    }
}

