using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropListApp.API.Models
{
	public class user
	{
		// scalar properties

		public int UserId { get; set; }
		public string EmaillAddress { get; set; }
		public string Password { get; set; }

		// navigation proerties 
		public virtual ICollection<Stocker> Stockers { get; set; }
		public virtual ICollection<Driver> Drivers { get; set; }
		public virtual ICollection<Building> Buildings { get; set; }



	}
}