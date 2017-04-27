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
using DropListApp.API.Models;
using DropListApp.API.data;

namespace DropListApp.API.Controllers
{
    public class StockersController : ApiController
    {
        private DropListAppDataContext db = new DropListAppDataContext();

		// GET: api/Stockers
		public IHttpActionResult GetStockers()
		{
			var resultSet = db.Stockers.Select(stocker => new
			{

				stocker.StockerId,
				stocker.FirstName,
				stocker.LastName,
				stocker.EmployeeNumber

			});


			return Ok(resultSet);
		}

		// GET: api/Stockers/5
		[ResponseType(typeof(Stocker))]
        public IHttpActionResult GetStocker(int id)
        {
            Stocker stocker = db.Stockers.Find(id);
            if (stocker == null)
            {
                return NotFound();
            }
			var resultSet = new
			{

				stocker.StockerId,
				stocker.FirstName,
				stocker.LastName,
				stocker.EmployeeNumber

			};

			return Ok(resultSet);
        }

        // PUT: api/Stockers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStocker(int id, Stocker stocker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stocker.StockerId)
            {
                return BadRequest();
            }
			var dbStocker = db.Stockers.Find(id);
			dbStocker.StockerId = stocker.StockerId;
			dbStocker.FirstName = stocker.FirstName;
			dbStocker.LastName = stocker.LastName;
			dbStocker.EmployeeNumber = stocker.EmployeeNumber;
            db.Entry(stocker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockerExists(id))
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

        // POST: api/Stockers
        [ResponseType(typeof(Stocker))]
        public IHttpActionResult PostStocker(Stocker stocker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stockers.Add(stocker);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stocker.StockerId }, new
			{

				stocker.StockerId,
				stocker.FirstName,
				stocker.LastName,
				stocker.EmployeeNumber

			});
        }

        // DELETE: api/Stockers/5
        [ResponseType(typeof(Stocker))]
        public IHttpActionResult DeleteStocker(int id)
        {
            Stocker stocker = db.Stockers.Find(id);
            if (stocker == null)
            {
                return NotFound();
            }

            db.Stockers.Remove(stocker);
            db.SaveChanges();
			var resultSet = new
			{
				stocker.StockerId,
				stocker.FirstName,
				stocker.LastName,
				stocker.EmployeeNumber
			};
            return Ok(resultSet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockerExists(int id)
        {
            return db.Stockers.Count(e => e.StockerId == id) > 0;
        }
    }
}