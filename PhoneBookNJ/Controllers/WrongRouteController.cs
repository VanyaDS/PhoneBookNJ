using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookNJ.Controllers
{
    public class WrongRouteController : Controller
    {
       
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            ViewBag.url = Request.Url.ToString().Remove(0, Request.Url.ToString().IndexOf(";") + 1);
            ViewBag.method = Request.HttpMethod;


            return View();
        }
    }
}