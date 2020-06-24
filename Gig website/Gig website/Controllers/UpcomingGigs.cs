using System;

namespace Gig_website.Controllers
{
    internal class UpcomingGigs
    {
        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }
        public byte GenreId { get; set; }
        public string Venue { get; set; }
    }
}