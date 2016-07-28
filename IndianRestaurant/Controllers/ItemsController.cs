﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IndianRestaurant.Models;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.Helpers;
/*
 * @File name : Item Controller
 * @Author : Ritesh Patel and Parvati Patel
 * @Website name : Taj Mahel(http://indianrestaurant.azurewebsites.net/)
 * @File description : This controller provides CRUD operation of item model
 */
namespace IndianRestaurant.Controllers
{
    public class ItemsController : Controller
    {
        private RestuarantModel db = new RestuarantModel();

        // GET: Items
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var items = db.Items.Include(i => i.Menu);
            return View(await items.ToListAsync());
        }

        // GET: Items/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item =  db.Items.Include(i=>i.Menu).Single(s=>s.ItemId==id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ItemId,MenuId,Name,Description,Price,OriginalImageUrl")] Item item)
        {
            bool flag = db.Items.Any(i => i.Name == item.Name);
            if (flag)
            {
                ViewBag.alert = "Item already exists!";
                ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "Name");
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        HttpPostedFileBase image = Request.Files["file"];
                        if (image != null)
                        {
                            //Originals file path
                            string filePathOriginal = "~/Assest/Uploads/Originals";
                            bool flag1 = System.IO.Directory.Exists(Server.MapPath(filePathOriginal));
                            //check if directory exists or not
                            if (!flag1)
                                System.IO.Directory.CreateDirectory(Server.MapPath(filePathOriginal));
                            //Thumbnails file path
                            string filePathThumbnail = "~/Assest/Uploads/Thumbnails";
                            bool flag2 = System.IO.Directory.Exists(Server.MapPath(filePathThumbnail));
                            //check if directory exists or not
                            if (!flag2)
                                System.IO.Directory.CreateDirectory(Server.MapPath(filePathThumbnail));
                            //Save image to file

                            string filename = image.FileName;
                            filename = Guid.NewGuid() + filename;



                            string savedFileName = Path.Combine(Server.MapPath(filePathOriginal), filename);
                            //save image into folder
                            image.SaveAs(savedFileName);
                            item.OriginalImageUrl = filename;
                            //Read image back from file and create thumbnail from it
                            Image imageFile = Image.FromFile(savedFileName);
                            int imgHeight = 100;
                            int imgWidth = 100;

                            Image thumb = imageFile.GetThumbnailImage(imgWidth, imgHeight, () => false, IntPtr.Zero);
                            filePathThumbnail = Path.Combine(Server.MapPath(filePathThumbnail), filename);
                            item.ThumbImageUrl = filename;
                            //save thumb image into folder
                            thumb.Save(filePathThumbnail);

                            db.Items.Add(item);
                            await db.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }


               
               
                   
            }

            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "Name", item.MenuId);
            return View(item);
        }

        // GET: Items/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "Name", item.MenuId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ItemId,MenuId,Name,Description,Price,OriginalImageUrl,ThumbImageUrl")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "Name", item.MenuId);
            return View(item);
        }

        // GET: Items/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Include(i => i.Menu).Single(s => s.ItemId == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Item item = db.Items.Include(i => i.Menu).Single(s => s.ItemId == id);
            db.Items.Remove(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
