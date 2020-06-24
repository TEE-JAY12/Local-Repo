using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using To_show.Controllers;

namespace To_show.Viewmodels
{
    public class infoformviewmodel
    {
        [Required]
        public string Name { get; set; }
        public int Id { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public string Sex { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<TestController, ActionResult>> update =
                   (c => c.Update(this));
                Expression<Func<TestController, ActionResult>> create = 
                   (c => c.display(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
                //return (Id != 0) ? "Update" : "display";
            }
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}