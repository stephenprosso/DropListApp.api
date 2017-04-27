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
    public class DriversController : ApiController
    {
        private DropListAppDataContext db = new DropListAppDataContext();

		// GET: api/Drivers
		public IHttpActionResult GetDrivers()
		{
			var resultSet = db.Drivers.Select(driver => new
			{

				driver.DriverId,
				driver.FirstName,
				driver.LastName,
				driver.EmployeeNumber

			});


            return Ok(resultSet);
        }

        // GET: api/Drivers/5
        [ResponseType(typeof(Driver))]
        public IHttpActionResult GetDriver(int id)
        {
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return NotFound();
            }
			var resultSet = new
			{

				driver.DriverId,
				driver.FirstName,
				driver.LastName,
				driver.EmployeeNumber

			};
			return Ok(resultSet);
		}

        // PUT: api/Drivers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriver(int id, Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driver.DriverId)
            {
                return BadRequest();
            }
			var dbDriver = db.Drivers.Find(id);
			dbDriver.DriverId = driver.DriverId;
			dbDriver.FirstName = driver.FirstName;
			dbDriver.LastName = driver.LastName;
			dbDriver.EmployeeNumber = driver.EmployeeNumber;

			db.Entry(driver).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

        // POST: api/Drivers
        [ResponseType(typeof(Driver))]
        public IHttpActionResult PostDriver(Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Drivers.Add(driver);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = driver.DriverId }, new
			{

				driver.DriverId,
				driver.FirstName,
				driver.LastName,
				driver.EmployeeNumber

			});
        }

        // DELETE: api/Drivers/5
        [ResponseType(typeof(Driver))]
        public IHttpActionResult DeleteDriver(int id)
        {
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return NotFound();
            }

            db.Drivers.Remove(driver);
            db.SaveChanges();

			var resultSet = new
			{

				driver.DriverId,
				driver.FirstName,
				driver.LastName,
				driver.EmployeeNumber

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

        private bool DriverExists(int id)
        {
            return db.Drivers.Count(e => e.DriverId == id) > 0;
        }
    }
}