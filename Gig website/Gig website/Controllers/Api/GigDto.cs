using Gig_website.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gig_website.Controllers.Api
{
    public class GigDto
    {
        public int Id { get; set; }

        public bool IsCanceled { get;  set; }



        public UserDto Artist { get; set; }

 

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }


        public GenreDto Genre { get; set; }

        

       
    }
}