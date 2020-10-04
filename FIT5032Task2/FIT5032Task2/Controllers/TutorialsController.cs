using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032Task2.Models;
using Microsoft.AspNet.Identity;

namespace FIT5032Task2.Controllers
{
    public class TutorialsController : Controller
    {
        private Task2_model db = new Task2_model();

        // GET: Tutorials
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var tutorials = db.Tutorials.Where(s => s.UserId ==
            userId).ToList();
            return View(tutorials);
           
        }

        // GET: Tutorials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutorials tutorials = db.Tutorials.Find(id);
            if (tutorials == null)
            {
                return HttpNotFound();
            }
            return View(tutorials);
        }

        // GET: Tutorials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tutorials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Name,tutorialTime,Introduction,Difficulty,SuitablePeople,UserId")] Tutorials tutorials)
        {

            tutorials.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(tutorials);
            if (ModelState.IsValid)
            {
                db.Tutorials.Add(tutorials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tutorials);
        }

        // GET: Tutorials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutorials tutorials = db.Tutorials.Find(id);
            if (tutorials == null)
            {
                return HttpNotFound();
            }
            return View(tutorials);
        }

        // POST: Tutorials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,tutorialTime,Introduction,Difficulty,SuitablePeople,UserId")] Tutorials tutorials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutorials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tutorials);
        }

        // GET: Tutorials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutorials tutorials = db.Tutorials.Find(id);
            if (tutorials == null)
            {
                return HttpNotFound();
            }
            return View(tutorials);
        }

        // POST: Tutorials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tutorials tutorials = db.Tutorials.Find(id);
            db.Tutorials.Remove(tutorials);
            db.SaveChanges();
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
