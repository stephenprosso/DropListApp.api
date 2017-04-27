using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DropListApp.API.Models;

namespace DropListApp.API.data
{
	public class DropListAppDataContext : DbContext
	{
		// contructor
		// Tells entity frame work during migrations our DB should be called DropListApp
		public DropListAppDataContext() : base("DropListApp")
		{

		}

		// dbsets

		public IDbSet<Building> Buildings { get; set; }
		public IDbSet<Droplist> Droplists { get; set; }
		public IDbSet<Stocker> Stockers { get; set; }
		public IDbSet<Driver> Drivers { get; set; }
		public IDbSet<user> Users { get; set; }


		// model configuration
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// building has many drop lists, drivers?, stockers?

			modelBuilder.Entity<Building>()
				.HasMany(Building => Building.Droplists)
				.WithRequired(droplist => droplist.Building)
				.HasForeignKey(droplist => droplist.BuildingId);
	

			//stocker has many droplists
			modelBuilder.Entity<Stocker>()
				.HasMany(stocker => stocker.Droplists)
				.WithRequired(droplist => droplist.Stocker)
				.HasForeignKey(droplist => droplist.StockerId);

			// driver has many droplists
			modelBuilder.Entity<Driver>()
				.HasMany(driver => driver.Droplists)
				.WithRequired(droplist => droplist.Driver)
				.HasForeignKey(droplist => droplist.DriverId);

		}

		public System.Data.Entity.DbSet<DropListApp.API.Models.user> users { get; set; }
	}
}