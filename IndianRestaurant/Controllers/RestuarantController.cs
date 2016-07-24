using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndianRestaurant.Controllers
{
    public class RestuarantController : Controller
    {
        // GET: Restuarant
        public ActionResult Index()
        {

            return View();
        }
    }
}