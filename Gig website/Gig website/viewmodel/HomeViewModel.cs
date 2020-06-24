using Gig_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gig_website.viewmodel
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get;set; }
        public string SearchTerm { get; set; }

    }
}