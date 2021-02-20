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

        // GET: Studentsubjects
        public ActionResult Index()
        {
            var studentsubjects = db.Studentsubjects.Include(s => s.student).Include(s => s.subject);
            return View(studentsubjects.ToList());
        }

        // GET: Studentsubjects/Details/5
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

        // GET: Studentsubjects/Create
        public ActionResult Create()
        {
            ViewBag.id_student = new SelectList(db.Students, "id", "name");
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject");
            return View();
        }

        // POST: Studentsubjects/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_student,id_subject")] Studentsubject studentsubject)
        {
            if (ModelState.IsValid)
            {
                db.Studentsubjects.Add(studentsubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_student = new SelectList(db.Students, "id", "name", studentsubject.id_student);
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject", studentsubject.id_subject);
            return View(studentsubject);
        }

        // GET: Studentsubjects/Edit/5
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

        // POST: Studentsubjects/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_student,id_subject")] Studentsubject studentsubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_student = new SelectList(db.Students, "id", "name", studentsubject.id_student);
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name_subject", studentsubject.id_subject);
            return View(studentsubject);
        }

        // GET: Studentsubjects/Delete/5
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

        // POST: Studentsubjects/Delete/5
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
