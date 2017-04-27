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
    public class DroplistsController : ApiController
    {
        private DropListAppDataContext db = new DropListAppDataContext();

        // GET: api/Droplists
        public IHttpActionResult GetDroplists()
        {
			var resultSet = db.Droplists.Select(droplist => new
			{
				droplist.DroplistId,
				droplist.BuildingId,
				droplist.StockerId,
				droplist.DriverId,
				droplist.DroplistName,
				droplist.Department,
				droplist.IsleNumber,
				droplist.IsleRow,
				droplist.IsleColumn,
				droplist.DroplistDate

			});
			
            return Ok(resultSet);
        }

        // GET: api/Droplists/5
        [ResponseType(typeof(Droplist))]
        public IHttpActionResult GetDroplist(int id)
        {
            Droplist droplist = db.Droplists.Find(id);
            if (droplist == null)
            {
                return NotFound();
            }
			var resultSet = new
			{
				droplist.DroplistId,
				droplist.BuildingId,
				droplist.StockerId,
				droplist.DriverId,
				droplist.DroplistName,
				droplist.Department,
				droplist.IsleNumber,
				droplist.IsleRow,
				droplist.IsleColumn,
				droplist.DroplistDate

			};
			return Ok(resultSet);
        }

        // PUT: api/Droplists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDroplist(int id, Droplist droplist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != droplist.DroplistId)
            {
                return BadRequest();
            }

			var dbDroplist = db.Droplists.Find(id);
			dbDroplist.DroplistId = droplist.DroplistId;
			dbDroplist.BuildingId = droplist.BuildingId;
			dbDroplist.StockerId = droplist.StockerId;
			dbDroplist.DriverId = droplist.DriverId;
			dbDroplist.DroplistName = droplist.DroplistName;
			dbDroplist.Department = droplist.Department;
			dbDroplist.IsleNumber = droplist.IsleNumber;
			dbDroplist.IsleRow = droplist.IsleRow;
			dbDroplist.IsleColumn = droplist.IsleColumn;
			dbDroplist.DroplistDate = droplist.DroplistDate;

			db.Entry(droplist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DroplistExists(id))
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

        // POST: api/Droplists
        [ResponseType(typeof(Droplist))]
        public IHttpActionResult PostDroplist(Droplist droplist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Droplists.Add(droplist);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = droplist.DroplistId }, new
			{
				droplist.DroplistId,
				droplist.BuildingId,
				droplist.StockerId,
				droplist.DriverId,
				droplist.DroplistName,
				droplist.Department,
				droplist.IsleNumber,
				droplist.IsleRow,
				droplist.IsleColumn,
				droplist.DroplistDate

			});
        }

        // DELETE: api/Droplists/5
        [ResponseType(typeof(Droplist))]
        public IHttpActionResult DeleteDroplist(int id)
        {
            Droplist droplist = db.Droplists.Find(id);
            if (droplist == null)
            {
                return NotFound();
            }

            db.Droplists.Remove(droplist);
            db.SaveChanges();
			var resultSet = new
			{
				droplist.DroplistId,
				droplist.BuildingId,
				droplist.StockerId,
				droplist.DriverId,
				droplist.DroplistName,
				droplist.Department,
				droplist.IsleNumber,
				droplist.IsleRow,
				droplist.IsleColumn,
				droplist.DroplistDate

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

        private bool DroplistExists(int id)
        {
            return db.Droplists.Count(e => e.DroplistId == id) > 0;
        }
    }
}