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
    public class RestSubjectteachersController : ApiController
    {
        private Model db = new Model();

        // GET: api/RestSubjectteachers
        public IQueryable<Subjectteacher> GetSubjectteachers()
        {
            return db.Subjectteachers;
        }

        // GET: api/RestSubjectteachers/5
        [ResponseType(typeof(Subjectteacher))]
        public IHttpActionResult GetSubjectteacher(int id)
        {
            Subjectteacher subjectteacher = db.Subjectteachers.Find(id);
            if (subjectteacher == null)
            {
                return NotFound();
            }

            return Ok(subjectteacher);
        }

        // PUT: api/RestSubjectteachers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubjectteacher(int id, Subjectteacher subjectteacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjectteacher.id)
            {
                return BadRequest();
            }

            db.Entry(subjectteacher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectteacherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/RestSubjectteachers
        [ResponseType(typeof(Subjectteacher))]
        public IHttpActionResult PostSubjectteacher(Subjectteacher subjectteacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subjectteachers.Add(subjectteacher);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.OK);
        }

        // DELETE: api/RestSubjectteachers/5
        [ResponseType(typeof(Subjectteacher))]
        public IHttpActionResult DeleteSubjectteacher(int id)
        {
            Subjectteacher subjectteacher = db.Subjectteachers.Find(id);
            if (subjectteacher == null)
            {
                return NotFound();
            }

            db.Subjectteachers.Remove(subjectteacher);
            db.SaveChanges();

            return Ok(subjectteacher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubjectteacherExists(int id)
        {
            return db.Subjectteachers.Count(e => e.id == id) > 0;
        }
    }
}