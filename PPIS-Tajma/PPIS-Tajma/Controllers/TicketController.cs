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
    public class TicketController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Ticket/
        public ActionResult Index()
        {
            return View(db.TicketModels.ToList());
        }

        // GET: /Ticket/
        public ActionResult Manager()
        {
            return View(db.TicketModels.ToList());
        }

        // GET: /Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModel ticketmodel = db.TicketModels.Find(id);
            if (ticketmodel == null)
            {
                return HttpNotFound();
            }
            return View(ticketmodel);
        }

        // GET: /Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title,Description,Location")] TicketModel ticketmodel)
        {
            if (ModelState.IsValid)
            {
                ticketmodel.UserName = User.Identity.Name;
                ticketmodel.Created = DateTime.Now;
                ticketmodel.Steps = "";
                ticketmodel.Actions = "";
                ticketmodel.Status = true;
                ticketmodel.Assigned = "";

                db.TicketModels.Add(ticketmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticketmodel);
        }

        // GET: /Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModel ticketmodel = db.TicketModels.Find(id);
            if (ticketmodel == null)
            {
                return HttpNotFound();
            }
            return View(ticketmodel);
        }

        // POST: /Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,UserName,Location,Steps,Actions,Status,Assigned")] TicketModel ticketmodel)
        {
            if (ModelState.IsValid)
            {
                ticketmodel.Created = DateTime.Now;
                //ticketmodel.Status = true;
                db.Entry(ticketmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manager");
            }
            return View(ticketmodel);
        }

        // GET: /Ticket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModel ticketmodel = db.TicketModels.Find(id);
            if (ticketmodel == null)
            {
                return HttpNotFound();
            }
            return View(ticketmodel);
        }

        // POST: /Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketModel ticketmodel = db.TicketModels.Find(id);
            db.TicketModels.Remove(ticketmodel);
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
