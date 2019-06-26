namespace CarDealership.UI.Migrations
{
	using CarDealership.UI.Models;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.UI.Models.ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(CarDealership.UI.Models.ApplicationDbContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.
			var store = new UserStore<ApplicationUser>(context);
			var userManager = new UserManager<ApplicationUser>(store);
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			if (!context.Users.Any(u => u.UserName == "admin@test.com"))
			{

				var user = new ApplicationUser { UserName = "admin@test.com" };

				userManager.Create(user, "Test123!");
				userManager.AddToRole(user.Id, "admin");
			}
			var sales = new IdentityRole { Name = "Sales" };
			var disabled = new IdentityRole { Name = "Disabled" };
			roleManager.Create(sales);
			roleManager.Create(disabled);


		}
	}
}

