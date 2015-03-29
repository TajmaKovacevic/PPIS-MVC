using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketingManagement.Model;
using PPIS_Tajma.Models;

namespace PPIS_Tajma.Controllers
{
    public class ChangeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Change/
        public ActionResult Index()
        {
            return View(db.ChangeTicketModels.ToList());
        }
        // GET: /Ticket/
        public ActionResult Manager()
        {
            return View(db.ChangeTicketModels.ToList());
        }
        // GET: /Change/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeTicketModel changeticketmodel = db.ChangeTicketModels.Find(id);
            if (changeticketmodel == null)
            {
                return HttpNotFound();
            }
            return View(changeticketmodel);
        }

        // GET: /Change/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Change/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title,Description,Location")] ChangeTicketModel changeticketmodel)
        {
            if (ModelState.IsValid)
            {
                changeticketmodel.UserName = User.Identity.Name;
                changeticketmodel.Created = DateTime.Now;
                changeticketmodel.Steps = "";
                changeticketmodel.Actions = "";
                changeticketmodel.Status = true;
                changeticketmodel.Assigned = "";
                db.ChangeTicketModels.Add(changeticketmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(changeticketmodel);
        }

        // GET: /Change/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeTicketModel changeticketmodel = db.ChangeTicketModels.Find(id);
            if (changeticketmodel == null)
            {
                return HttpNotFound();
            }
            return View(changeticketmodel);
        }

        // POST: /Change/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title,Description,UserName,Location,Steps,Actions,Status,Assigned")] ChangeTicketModel changeticketmodel)
        {
            if (ModelState.IsValid)
            {
                changeticketmodel.Created = DateTime.Now;
                //changeticketmodel.Status = true;
                db.Entry(changeticketmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manager");
            }
            return View(changeticketmodel);
        }

        // GET: /Change/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeTicketModel changeticketmodel = db.ChangeTicketModels.Find(id);
            if (changeticketmodel == null)
            {
                return HttpNotFound();
            }
            return View(changeticketmodel);
        }

        // POST: /Change/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChangeTicketModel changeticketmodel = db.ChangeTicketModels.Find(id);
            db.ChangeTicketModels.Remove(changeticketmodel);
            db.SaveChanges();
            return RedirectToAction("Manager");
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
