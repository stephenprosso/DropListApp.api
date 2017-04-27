using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropListApp.API.Models
{
	public class Driver
	{
		// scalar properties

		public int DriverId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int EmployeeNumber { get; set; }

		//navigation properties
		public virtual ICollection<Droplist> Droplists { get; set; }

	}
}