using Gig_website.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gig_website.Controllers.Api
{
    public class NotificationDTO
    {
       
        public DateTime DateTime { get;  set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get;  set; }
        public string OriginalVenue { get;  set; }
        public GigDto Gig { get;  set; }
    }
}