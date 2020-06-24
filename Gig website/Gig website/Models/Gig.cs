using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gig_website.Models
{
    public class Gig
    {


        public int Id { get; set; }

        public bool IsCanceled { get;private  set; }
        
      

        public ApplicationUser Artist { get; set; }

        [Required]
        public String ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }


        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public ICollection<Attendance> Attendances {get; private set;}

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }


        public void Cancel()
        {

            IsCanceled = true;
            // var notification = new Notification(NotificationType.GigCancalled, this);
            var notification = Notification.GigCancelled(this);


            foreach (var attendee in  Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
                
            }
        }

     public void Modify(DateTime dateTime,string venue,byte genre)
        {
            //var notification = new Notification(NotificationType.GigUpdated, this);
            //notification.OriginalDateTime = DateTime;
            //notification.OriginalVenue = venue;

            var notification = Notification.GigUpdated(this, DateTime, Venue);
            Venue = venue;
            DateTime = dateTime;
            GenreId = genre;


            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);

            }
        }

        public void Create()
        {
            var notification = Notification.GigCreated(this);
        }
    }
    
}