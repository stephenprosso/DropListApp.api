using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropListApp.API.Models
{
	public class Department
	{
		public int DepartmentId { get; set; }
		public int DepartmentName { get; set; }
		public int BuildingId { get; set; }
		public int DriverId { get; set; }
		public int StockerId { get; set; }
		

		//navigation properties
		public virtual ICollection<Driver> Drivers { get; set; }
		public virtual ICollection<Stocker> Stockers { get; set; }


	}
}