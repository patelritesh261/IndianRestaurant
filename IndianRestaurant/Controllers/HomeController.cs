using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndianRestaurant.Models;
using System.Net;
using System.Threading.Tasks;
/*
 * @File name : Home Controller
 * @Author : Ritesh Patel and Parvati Patel
 * @Website name : Taj Mahel(http://indianrestaurant.azurewebsites.net/)
 * @File description : This control provides cilent side view
 */
namespace IndianRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private RestuarantModel db = new RestuarantModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Menu()
        {
            //return menu and associated items from database
            Menu[] MenuModel = db.Menus.Include("Item").ToArray();

            return View(MenuModel);
        }
        //home/ItemDetails/14
        public ActionResult ItemDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //get particular ddetails of menu
            Item item = db.Items.Include("Menu").Single(g=>g.ItemId==id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
    }
}