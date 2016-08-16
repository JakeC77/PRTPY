using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZimtProcure2Pay.Models;

namespace ZimtProcure2Pay.Controllers
{
    public class MobileRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MobileRequests
        public ActionResult Index()
        {
            return View(db.MobileRequests.ToList());
        }

        public ActionResult PostRequest()
        {
            foreach (string file in Request.Files)
            {
                var fName = Request.Files[file].FileName;
                string text = Request.Params.Get("text");
                var fileContent = Request.Files[file];
                var stream = fileContent.InputStream;
                if (!string.IsNullOrEmpty(fName))
                {
                    var fPath = Path.Combine(Server.MapPath("~/Resources/Posts/"), fName);
                    using (var fileStream = System.IO.File.Create(fPath))
                    {
                        stream.CopyTo(fileStream);
                    }
                    MobileRequest req = new MobileRequest
                    {
                        Created = DateTime.Now,
                        ImageUrl = fName,
                        Priority = 0,
                        Status = 0,
                        Text = text
                    };
                    db.MobileRequests.Add(req);
                    db.SaveChanges();
                    return Json("Request added successfully");
                }
            }
            return Json("Error creating request");
        }

        // GET: MobileRequests/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileRequest mobileRequest = db.MobileRequests.Find(id);
            if (mobileRequest == null)
            {
                return HttpNotFound();
            }
            return View(mobileRequest);
        }

        // GET: MobileRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MobileRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MobileRequestID,Text,Created,Status,Priority,Placed,ImageUrl")] MobileRequest mobileRequest)
        {
            if (ModelState.IsValid)
            {
                db.MobileRequests.Add(mobileRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mobileRequest);
        }

        // GET: MobileRequests/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileRequest mobileRequest = db.MobileRequests.Find(id);
            if (mobileRequest == null)
            {
                return HttpNotFound();
            }
            return View(mobileRequest);
        }

        // POST: MobileRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MobileRequestID,Text,Created,Status,Priority,Placed,ImageUrl")] MobileRequest mobileRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobileRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mobileRequest);
        }

        // GET: MobileRequests/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileRequest mobileRequest = db.MobileRequests.Find(id);
            if (mobileRequest == null)
            {
                return HttpNotFound();
            }
            return View(mobileRequest);
        }

        // POST: MobileRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MobileRequest mobileRequest = db.MobileRequests.Find(id);
            db.MobileRequests.Remove(mobileRequest);
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
