using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace To_show.Models
{
    public class Information
    {   [Required]
        public string Name { get; set; }
        public bool IsCanceled { get; set; }
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public string Sex { get; set; }

    }
}