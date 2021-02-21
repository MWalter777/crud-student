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
    public class StudentsubjectsController : Controller
    {
        private Model db = new Model();

        public ActionResult Index()
        {
            var studentsubjects = db.Studentsubjects.Include(s => s.student).Include(s => s.subject);
            return View(studentsubjects.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentsubject studentsubject = db.Studentsubjects.Find(id);
            if (studentsubject == null)
            {
                return HttpNotFound();
            }
            return View(studentsubject);
        }


        public ActionResult Create()
        {
            ViewBag.id_student = new SelectList(db.Students, "id", "name");
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_student,id_subject,examen1,examen2,examen3,examen4")] Studentsubject studentsubject)
        {
            if (ModelState.IsValid)
            {
                Studentsubject ss2 = db.Studentsubjects.ToList().Find(value => value.id_student == studentsubject.id_student && value.id_subject == studentsubject.id_subject);
                if (ss2 == null)
                {
                    if (studentsubject.examen1 >= 0 && studentsubject.examen1 <= 10 && studentsubject.examen2 >= 0 && studentsubject.examen2 <= 10 && studentsubject.examen3 >= 0 && studentsubject.examen3 <= 10 && studentsubject.examen4 >= 0 && studentsubject.examen4 <= 10)
                    {
                        db.Studentsubjects.Add(studentsubject);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }else
                    {
                        ViewBag.error = "Error, Score must be between 0 and 10";
                    }
                }else
                {
                    ViewBag.error = "Error, Student already have the score!";
                }
            }

            ViewBag.id_student = new SelectList(db.Students, "id", "name", studentsubject.id_student);
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject", studentsubject.id_subject);
            return View(studentsubject);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentsubject studentsubject = db.Studentsubjects.Find(id);
            if (studentsubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_student = new SelectList(db.Students, "id", "name", studentsubject.id_student);
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject", studentsubject.id_subject);
            return View(studentsubject);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_student,id_subject,examen1,examen2,examen3,examen4")] Studentsubject studentsubject)
        {
            if (ModelState.IsValid)
            {
                if (studentsubject.examen1 >= 0 && studentsubject.examen1 <= 10 && studentsubject.examen2 >= 0 && studentsubject.examen2 <= 10 && studentsubject.examen3 >= 0 && studentsubject.examen3 <= 10 && studentsubject.examen4 >= 0 && studentsubject.examen4 <= 10)
                {
                    db.Entry(studentsubject).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Error, Score must be between 0 and 10";
                }
            }
            ViewBag.id_student = new SelectList(db.Students, "id", "name", studentsubject.id_student);
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject", studentsubject.id_subject);
            return View(studentsubject);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentsubject studentsubject = db.Studentsubjects.Find(id);
            if (studentsubject == null)
            {
                return HttpNotFound();
            }
            return View(studentsubject);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studentsubject studentsubject = db.Studentsubjects.Find(id);
            db.Studentsubjects.Remove(studentsubject);
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
