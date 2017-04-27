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
    public class usersController : ApiController
    {
        private DropListAppDataContext db = new DropListAppDataContext();

        // GET: api/users
        public IHttpActionResult Getusers()
        {

			var resultSet = db.Users.Select(user => new
			{
				user.UserId,
				user.EmaillAddress,
				user.Password,
			});

            return Ok(resultSet);
        }

        // GET: api/users/5
        [ResponseType(typeof(user))]
        public IHttpActionResult Getuser(int id)
        {
            user user = db.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
			var resultSet = new
			{
				user.UserId,
				user.EmaillAddress,
				user.Password,
			};
			return Ok(resultSet);
        }

        // PUT: api/users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putuser(int id, user user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }
			var dbUsers = db.Users.Find(id);
			dbUsers.UserId = user.UserId;
			dbUsers.EmaillAddress = user.EmaillAddress;
			dbUsers.Password = user.Password;
            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(id))
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

        // POST: api/users
        [ResponseType(typeof(user))]
        public IHttpActionResult Postuser(user user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, new
			{
				user.UserId,
				user.EmaillAddress,
				user.Password,
			});
        }

        // DELETE: api/users/5
        [ResponseType(typeof(user))]
        public IHttpActionResult Deleteuser(int id)
        {
            user user = db.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.users.Remove(user);
            db.SaveChanges();
			var resultsSet = new
			{
				user.UserId,
				user.EmaillAddress,
				user.Password,
			};
			return Ok(resultsSet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool userExists(int id)
        {
            return db.users.Count(e => e.UserId == id) > 0;
        }
    }
}