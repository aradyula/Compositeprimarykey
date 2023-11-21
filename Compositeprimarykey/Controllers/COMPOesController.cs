using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Compositeprimarykey.Models;

namespace Compositeprimarykey.Controllers
{
    public class COMPOesController : Controller
    {
        private RamyaEntities db = new RamyaEntities();

        // GET: COMPOes
        public ActionResult Index()
        {
            

            return View(db.COMPOes.ToList());
        }
        public ActionResult GetData() {
            var customersList = db.COMPOes.ToList<COMPO>();
            return Json(new { data = customersList}, JsonRequestBehavior.AllowGet);

        }
        public ActionResult DTable()
        {
            return View();
        }
        public ActionResult Accordin()
        {
            return View();
        }

        // GET: COMPOes/Details/5
        public ActionResult Details(int? EMP_ID, int? DEPT_ID)
        {
            if ( EMP_ID == null && DEPT_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPO cOMPO = db.COMPOes.Find( EMP_ID, DEPT_ID);
            if (cOMPO == null)
            {
                return HttpNotFound();
            }
            return View(cOMPO);
        }

        // GET: COMPOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: COMPOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMP_ID,DEPT_ID,EMPNAME,GENDER,SALARY")] COMPO cOMPO)
        {
            if (ModelState.IsValid)
            {
                db.COMPOes.Add(cOMPO);
                db.SaveChanges();
                return RedirectToAction("DTable");
            }

            return View(cOMPO);
        }

        // GET: COMPOes/Edit/5
        public ActionResult Edit(int? EMP_ID,int? DEPT_ID )
        {
            if (EMP_ID == null && DEPT_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPO cOMPO = db.COMPOes.Find(EMP_ID, DEPT_ID);
            if (cOMPO == null)
            {
                return HttpNotFound();
            }
            return View(cOMPO);
        }

        // POST: COMPOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMP_ID,DEPT_ID,EMPNAME,GENDER,SALARY")] COMPO cOMPO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DTable");
            }
            return View(cOMPO);
        }

        // GET: COMPOes/Delete/5
        public ActionResult Delete(int? EMP_ID, int? DEPT_ID)
        {
            if (EMP_ID == null && DEPT_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPO cOMPO = db.COMPOes.Find(EMP_ID, DEPT_ID);
            if (cOMPO == null)
            {
                return HttpNotFound();
            }
            return View(cOMPO);
        }

        // POST: COMPOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? EMP_ID, int? DEPT_ID)
        {
            COMPO cOMPO = db.COMPOes.Find(EMP_ID, DEPT_ID);
            db.COMPOes.Remove(cOMPO);
            db.SaveChanges();
            return RedirectToAction("DTable");
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
