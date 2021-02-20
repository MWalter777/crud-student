using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crud_students.Models;

namespace crud_students.Controllers
{
    public class SubjectteachersController : Controller
    {
        private Model db = new Model();

        // GET: Subjectteachers
        public ActionResult Index()
        {
            var subjectteachers = db.Subjectteachers.Include(s => s.subject).Include(s => s.teacher);
            return View(subjectteachers.ToList());
        }

        // GET: Subjectteachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subjectteacher subjectteacher = db.Subjectteachers.Find(id);
            if (subjectteacher == null)
            {
                return HttpNotFound();
            }
            return View(subjectteacher);
        }

        // GET: Subjectteachers/Create
        public ActionResult Create()
        {
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject");
            ViewBag.id_teacher = new SelectList(db.Teachers, "id", "name");
            return View();
        }

        // POST: Subjectteachers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_subject,id_teacher")] Subjectteacher subjectteacher)
        {
            if (ModelState.IsValid)
            {
                db.Subjectteachers.Add(subjectteacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject", subjectteacher.id_subject);
            ViewBag.id_teacher = new SelectList(db.Teachers, "id", "name", subjectteacher.id_teacher);
            return View(subjectteacher);
        }

        // GET: Subjectteachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subjectteacher subjectteacher = db.Subjectteachers.Find(id);
            if (subjectteacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject", subjectteacher.id_subject);
            ViewBag.id_teacher = new SelectList(db.Teachers, "id", "name", subjectteacher.id_teacher);
            return View(subjectteacher);
        }

        // POST: Subjectteachers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_subject,id_teacher")] Subjectteacher subjectteacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectteacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject", subjectteacher.id_subject);
            ViewBag.id_teacher = new SelectList(db.Teachers, "id", "name", subjectteacher.id_teacher);
            return View(subjectteacher);
        }

        // GET: Subjectteachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subjectteacher subjectteacher = db.Subjectteachers.Find(id);
            if (subjectteacher == null)
            {
                return HttpNotFound();
            }
            return View(subjectteacher);
        }

        // POST: Subjectteachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subjectteacher subjectteacher = db.Subjectteachers.Find(id);
            db.Subjectteachers.Remove(subjectteacher);
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
