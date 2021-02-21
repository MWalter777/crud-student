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

        public ActionResult Index()
        {
            var subjectteachers = db.Subjectteachers.Include(s => s.subject).Include(s => s.teacher);
            return View(subjectteachers.ToList());
        }

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


        public ActionResult Create()
        {
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject");
            ViewBag.id_teacher = new SelectList(db.Teachers, "id", "name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_subject,id_teacher")] Subjectteacher subjectteacher)
        {
            if (ModelState.IsValid)
            {
                Subjectteacher st2 = db.Subjectteachers.ToList().Find(value => value.id_subject == subjectteacher.id_subject && value.id_teacher == subjectteacher.id_teacher);
                if (st2 == null)
                {
                    db.Subjectteachers.Add(subjectteacher);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }else
                {
                    ViewBag.error = "Error, ya existe ese profesor en esa materia";
                }
            }

            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject", subjectteacher.id_subject);
            ViewBag.id_teacher = new SelectList(db.Teachers, "id", "name", subjectteacher.id_teacher);
            return View(subjectteacher);
        }


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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_subject,id_teacher")] Subjectteacher subjectteacher)
        {
            if (ModelState.IsValid)
            {
                Subjectteacher st2 = db.Subjectteachers.ToList().Find(value => value.id_subject == subjectteacher.id_subject && value.id_teacher == subjectteacher.id_teacher);
                if (st2 == null)
                {
                    db.Entry(subjectteacher).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Error, ya existe ese profesor en esa materia";
                }
            }
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject", subjectteacher.id_subject);
            ViewBag.id_teacher = new SelectList(db.Teachers, "id", "name", subjectteacher.id_teacher);
            return View(subjectteacher);
        }


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
