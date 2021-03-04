using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using crud_students.Models;

namespace crud_students.Controllers
{
    public class RestStudentsubjectsController : ApiController
    {
        private Model db = new Model();

        // GET: api/RestStudentsubjects
        public IQueryable<Studentsubject> GetStudentsubjects()
        {
            return db.Studentsubjects;
        }

        // GET: api/RestStudentsubjects/5
        [ResponseType(typeof(Studentsubject))]
        public IHttpActionResult GetStudentsubject(int id)
        {
            Studentsubject studentsubject = db.Studentsubjects.Find(id);
            if (studentsubject == null)
            {
                return NotFound();
            }

            return Ok(studentsubject);
        }

        // PUT: api/RestStudentsubjects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentsubject(int id, Studentsubject studentsubject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentsubject.id)
            {
                return BadRequest();
            }

            db.Entry(studentsubject).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsubjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RestStudentsubjects
        [ResponseType(typeof(Studentsubject))]
        public IHttpActionResult PostStudentsubject(Studentsubject studentsubject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Studentsubjects.Add(studentsubject);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = studentsubject.id }, studentsubject);
        }

        // DELETE: api/RestStudentsubjects/5
        [ResponseType(typeof(Studentsubject))]
        public IHttpActionResult DeleteStudentsubject(int id)
        {
            Studentsubject studentsubject = db.Studentsubjects.Find(id);
            if (studentsubject == null)
            {
                return NotFound();
            }

            db.Studentsubjects.Remove(studentsubject);
            db.SaveChanges();

            return Ok(studentsubject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentsubjectExists(int id)
        {
            return db.Studentsubjects.Count(e => e.id == id) > 0;
        }
    }
}