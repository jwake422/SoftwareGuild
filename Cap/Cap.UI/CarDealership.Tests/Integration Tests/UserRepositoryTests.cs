﻿using CarDealership.Data.ProductRepository;
using CarDealership.Models.Queries;
using CarDealership.UI.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.Integration_Tests
{
	[TestFixture]
	public class UserRepositoryTests
	{
		[Test]
		public void CanGetAllUsers()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			var repo = UsersRepositoryFactory.GetRepository();
			var users = repo.GetAll();

			Assert.AreEqual(1, users.Count);
		}
		[Test]
		public void CanAddUsers()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			UserItem item = new UserItem();
			item.FirstName = "Jeremy";
			item.LastName = "Wakefield";
			item.Email = "test@test.com";
			item.LockoutEnabled = false;
			item.RoleId = "sales";
			item.PasswordHash = "password";
			item.UserId = "d10dee9d-5dc7-44e3-b550-10cb35982cf5";
			item.EmailConfirmed = true;
			item.PhoneNumberConfirmed = false;
			item.TwoFactorEnabled = false;
			item.LockoutEnabled = false;
			item.AccessFailedCount = false;

			var repo = UsersRepositoryFactory.GetRepository();
			repo.AddUser(item);

			var users = repo.GetAll();
			Assert.AreEqual(2, users.Count);
			Assert.AreEqual("d10dee9d-5dc7-44e3-b550-10cb35982cf5", users[1].UserId);

		}

		[Test]
		public void CanEditUser()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			UserItem item = new UserItem();
			item.FirstName = "Jeremy";
			item.LastName = "Wakefield";
			item.Email = "test@test.com";
			item.LockoutEnabled = false;
			item.RoleId = "sales";
			item.PasswordHash = "password";
			item.UserId = "d10dee9d-5dc7-44e3-b550-10cb35982cf5";
			item.EmailConfirmed = true;
			item.PhoneNumberConfirmed = false;
			item.TwoFactorEnabled = false;
			item.LockoutEnabled = false;
			item.AccessFailedCount = false;

			var repo = UsersRepositoryFactory.GetRepository();
			repo.AddUser(item);

			item.RoleId = "Admin";
			item.UserId = "d10dee9d-5dc7-44e3-b550-10cb35982cf5";

			repo.EditUser(item);

			var users = repo.GetAll();
			Assert.AreEqual(2, users.Count);
			Assert.AreEqual("Admin", users[1].RoleId);
		}

		[Test]
		public void CanEditPassword()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			UserItem item = new UserItem();
			item.FirstName = "Jeremy";
			item.LastName = "Wakefield";
			item.Email = "test@test.com";
			item.LockoutEnabled = false;
			item.RoleId = "sales";
			item.PasswordHash = "password";
			item.UserId = "d10dee9d-5dc7-44e3-b550-10cb35982cf5";
			item.EmailConfirmed = true;
			item.PhoneNumberConfirmed = false;
			item.TwoFactorEnabled = false;
			item.LockoutEnabled = false;
			item.AccessFailedCount = false;

			var repo = UsersRepositoryFactory.GetRepository();
			repo.AddUser(item);

			item.PasswordHash = "password123";
			item.UserId = "d10dee9d-5dc7-44e3-b550-10cb35982cf5";

			repo.EditPassword(item);

			var users = repo.GetAll();
			Assert.AreEqual(2, users.Count);
			Assert.AreEqual("password123", users[1].PasswordHash);
		}
	}
}
