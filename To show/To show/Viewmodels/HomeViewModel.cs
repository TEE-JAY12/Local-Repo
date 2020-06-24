using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using To_show.Models;

namespace To_show.Viewmodels
{
    public class HomeViewModel
    {
        public IEnumerable<Information> Info { get; set; }
    }
}