using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class ArithmeticController : Controller
    {
        // GET: Arithmetic
        public ActionResult Index( values val ,string Cal)
        {
            //switch (Cal)
            //{
            //    case "Add":
            //        ViewBag.Result = val.A + val.B;
            //        break;
            //    case "Sub":
            //        ViewBag.Result = val.A - val.B;
            //        break;
            //    case "Mul":
            //        ViewBag.Result = val.A  * val.B;
            //        break;
            //    case "Div":
            //        ViewBag.Result = val.A / val.B;
            //        break;
            //}
            switch (Cal)
            {
                case "Add":
                    val.Result = val.A + val.B;
                    break;
                case "Sub":
                    val.Result = val.A - val.B;
                    break;
                case "Mul":
                    val.Result = val.A * val.B;
                    break;
                case "Div":
                    val.Result = val.A / val.B;
                    break;
            }
            ViewBag.Result = val.Result;
            val.A = val.Result;
            return View();
        }
    }
}