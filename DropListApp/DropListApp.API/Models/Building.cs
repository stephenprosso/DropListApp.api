using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropListApp.API.Models
{
	public class Building
	{

		// Scalar Properties

		public int BuildingId { get; set; }
		public int DroplistId { get; set; }
		public int BuildingNumber { get; set; }
		public int DriverId { get; set; }
		public int StockerId { get; set; }
		public int EmployeeNumber { get; set; }
		public string BuildingName { get; set; }
		public string Telephone { get; set; }
		public string StreetAddress { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		
		// Navigation properties
		public virtual ICollection<Droplist> Droplists { get; set; }
		public virtual ICollection<Stocker> Stockers { get; set; }
		public virtual ICollection<Driver> Drivers { get; set; }

	}
}