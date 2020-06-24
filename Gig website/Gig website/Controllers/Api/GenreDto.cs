using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gig_website.Controllers.Api
{
    public class GenreDto
    {
        public byte Id { get; set; }
    
        public string Name { get; set; }
    }
}