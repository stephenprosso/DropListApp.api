using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropListApp.API.Models
{
	public class Droplist
	{
		// scalar properties
		public int DroplistId { get; set; }
		public int BuildingId { get; set; }
		public int StockerId { get; set; }
		public int DriverId { get; set; }
		public string DroplistName { get; set; }
		public string Department { get; set; }
		public int IsleNumber { get; set; }
		public string IsleRow { get; set; }
		public int IsleColumn { get; set; }
		public DateTime? DroplistDate { get; set; }

		// navigation properties
		public virtual Building Building { get; set; }
		public virtual Stocker Stocker { get; set; }
		public virtual Driver Driver { get; set; }
	}
}