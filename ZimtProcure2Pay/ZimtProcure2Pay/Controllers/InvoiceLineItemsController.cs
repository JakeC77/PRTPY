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
    public class InvoiceLineItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InvoiceLineItems
        public ActionResult Index()
        {
            return View(db.InvoiceLineItems.ToList());
        }

        // GET: InvoiceLineItems/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceLineItem invoiceLineItem = db.InvoiceLineItems.Find(id);
            if (invoiceLineItem == null)
            {
                return HttpNotFound();
            }
            return View(invoiceLineItem);
        }

        // GET: InvoiceLineItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceLineItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceLineItemID,UniversalID,RequisitionNumber,ItemNumber,Description,Quantity,Unit")] InvoiceLineItem invoiceLineItem)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceLineItems.Add(invoiceLineItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoiceLineItem);
        }

        // GET: InvoiceLineItems/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceLineItem invoiceLineItem = db.InvoiceLineItems.Find(id);
            if (invoiceLineItem == null)
            {
                return HttpNotFound();
            }
            return View(invoiceLineItem);
        }

        // POST: InvoiceLineItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceLineItemID,UniversalID,RequisitionNumber,ItemNumber,Description,Quantity,Unit")] InvoiceLineItem invoiceLineItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceLineItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoiceLineItem);
        }

        // GET: InvoiceLineItems/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceLineItem invoiceLineItem = db.InvoiceLineItems.Find(id);
            if (invoiceLineItem == null)
            {
                return HttpNotFound();
            }
            return View(invoiceLineItem);
        }

        // POST: InvoiceLineItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            InvoiceLineItem invoiceLineItem = db.InvoiceLineItems.Find(id);
            db.InvoiceLineItems.Remove(invoiceLineItem);
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
