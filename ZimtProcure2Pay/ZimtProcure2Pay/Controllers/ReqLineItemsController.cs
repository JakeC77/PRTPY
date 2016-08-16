using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZimtProcure2Pay.Models;

namespace ZimtProcure2Pay.Controllers
{
    public class ReqLineItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReqLineItems
        public ActionResult Index()
        {
            return View(db.ReqLineItems.ToList());
        }

        // GET: ReqLineItems/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqLineItem reqLineItem = db.ReqLineItems.Find(id);
            if (reqLineItem == null)
            {
                return HttpNotFound();
            }
            return View(reqLineItem);
        }

        // GET: ReqLineItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReqLineItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReqLineItemID,UniversalID,RequisitionID,ItemNumber,Description,Qty,Unit,Total,Expected,Status,PONumber")] ReqLineItem reqLineItem)
        {
            if (ModelState.IsValid)
            {
                db.ReqLineItems.Add(reqLineItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reqLineItem);
        }

        // GET: ReqLineItems/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqLineItem reqLineItem = db.ReqLineItems.Find(id);
            if (reqLineItem == null)
            {
                return HttpNotFound();
            }
            return View(reqLineItem);
        }

        // POST: ReqLineItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReqLineItemID,UniversalID,RequisitionID,ItemNumber,Description,Qty,Unit,Total,Expected,Status,PONumber")] ReqLineItem reqLineItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reqLineItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reqLineItem);
        }

        // GET: ReqLineItems/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqLineItem reqLineItem = db.ReqLineItems.Find(id);
            if (reqLineItem == null)
            {
                return HttpNotFound();
            }
            return View(reqLineItem);
        }

        // POST: ReqLineItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ReqLineItem reqLineItem = db.ReqLineItems.Find(id);
            db.ReqLineItems.Remove(reqLineItem);
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
