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
    public class RestDirectionsController : ApiController
    {
        private Model db = new Model();

        // GET: api/RestDirections
        public IQueryable<Direction> GetDirections()
        {
            return db.Directions;
        }

        // GET: api/RestDirections/5
        [ResponseType(typeof(Direction))]
        public IHttpActionResult GetDirection(int id)
        {
            Direction direction = db.Directions.Find(id);
            if (direction == null)
            {
                return NotFound();
            }

            return Ok(direction);
        }

        // PUT: api/RestDirections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDirection(int id, Direction direction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != direction.id)
            {
                return BadRequest();
            }

            db.Entry(direction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectionExists(id))
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

        // POST: api/RestDirections
        [ResponseType(typeof(Direction))]
        public IHttpActionResult PostDirection(Direction direction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Directions.Add(direction);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.OK);
        }

        // DELETE: api/RestDirections/5
        [ResponseType(typeof(Direction))]
        public IHttpActionResult DeleteDirection(int id)
        {
            Direction direction = db.Directions.Find(id);
            if (direction == null)
            {
                return NotFound();
            }

            db.Directions.Remove(direction);
            db.SaveChanges();

            return Ok(direction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DirectionExists(int id)
        {
            return db.Directions.Count(e => e.id == id) > 0;
        }
    }
}