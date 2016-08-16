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
    public class WorkGroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkGroups
        public ActionResult Index()
        {
            return View(db.WorkGroups.ToList());
        }

        // GET: WorkGroups/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkGroup workGroup = db.WorkGroups.Find(id);
            if (workGroup == null)
            {
                return HttpNotFound();
            }
            return View(workGroup);
        }

        // GET: WorkGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddUserToGroup(string userID, long groupID)
        {
            var wg = db.User_WorkGroups.FirstOrDefault(g => g.WorkGroupID == groupID && g.UserID == userID);
            if(wg == null)
            {
                wg = new User_WorkGroup
                {
                    UserID = userID,
                    WorkGroupID = groupID
                };
                db.User_WorkGroups.Add(wg);
                db.SaveChanges();
            }
            return Json(wg);
        }
        public ActionResult RemoveUserFromGroup(string userID, long groupID)
        {
            var wg = db.User_WorkGroups.FirstOrDefault(g => g.WorkGroupID == groupID && g.UserID == userID);
            if (wg != null)
            {
                db.User_WorkGroups.Remove(wg);
                db.SaveChanges();
            }
            return Json(wg);
        }

        public ActionResult AddWorkGroupRole(string userID, long groupID, string roleName)
        {
            var role = db.GroupRoles.FirstOrDefault(r => r.Name == roleName && r.UserID == userID && r.WorkGroupID == groupID);
            if(role == null)
            {
                role = new WorkGroupRole
                {
                    Name = roleName,
                    UserID = userID,
                    WorkGroupID = groupID
                };
                db.GroupRoles.Add(role);
                db.SaveChanges();
            }
            return Json(role);
        }

        public ActionResult RemoveWorkGroupRole(string userID, long groupID, string roleName)
        {
            var role = db.GroupRoles.FirstOrDefault(r => r.Name == roleName && r.UserID == userID && r.WorkGroupID == groupID);
            if (role != null)
            {
                db.GroupRoles.Remove(role);
                db.SaveChanges();
            }
            return Json(role);
        }

        public class RoleView
        {
            public ApplicationUser user { get; set; }

            public string roleName { get; set; }
        }

        public ActionResult GetWorkGroupRoles(long groupID)
        {
            var roles = db.GroupRoles.Where(r => r.WorkGroupID == groupID);
            List<RoleView> views = new List<RoleView>();
            foreach(var role in roles)
            {
                var user = db.Users.Find(role.UserID);
                var view = new RoleView
                {
                    roleName = role.Name,
                    user = user
                };
                views.Add(view);
            }
            return Json(views);
        }

        // POST: WorkGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkGroupID,UniversalID,Name,CreatedOn")] WorkGroup workGroup)
        {
            if (ModelState.IsValid)
            {
                db.WorkGroups.Add(workGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workGroup);
        }

        // GET: WorkGroups/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkGroup workGroup = db.WorkGroups.Find(id);
            if (workGroup == null)
            {
                return HttpNotFound();
            }
            return View(workGroup);
        }

        // POST: WorkGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkGroupID,UniversalID,Name,CreatedOn")] WorkGroup workGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workGroup);
        }

        // GET: WorkGroups/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkGroup workGroup = db.WorkGroups.Find(id);
            if (workGroup == null)
            {
                return HttpNotFound();
            }
            return View(workGroup);
        }

        // POST: WorkGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            WorkGroup workGroup = db.WorkGroups.Find(id);
            db.WorkGroups.Remove(workGroup);
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
