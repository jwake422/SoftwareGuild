﻿using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ProductRepository
{
	public class UsersRepository : IUsersRepository
	{
		public List<UserItem> GetAll()
		{
			{
				using (var cn = new SqlConnection())
				{
					cn.ConnectionString = Settings.GetConnectionString();

					return cn.Query<UserItem>("GetAllUsers",
						commandType: CommandType.StoredProcedure).ToList();
				}
			}
		}

		public void AddUser(UserItem user)
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();
				var parameters = new DynamicParameters();
				parameters.Add("@UserId", user.UserId);
				parameters.Add("@FirstName", user.FirstName);
				parameters.Add("@LastName", user.LastName);
				parameters.Add("@LockOutEnabled", user.LockoutEnabled);
				parameters.Add("@RoleId", user.RoleId);
				parameters.Add("@UserName", user.FirstName + " " + user.LastName);
				parameters.Add("@PasswordHash", user.PasswordHash);
				parameters.Add("@Email", user.Email);
				parameters.Add("@PhoneNumberConfirmed", user.PhoneNumberConfirmed);
				parameters.Add("@EmailConfirmed", user.EmailConfirmed);
				parameters.Add("@TwoFactorEnabled", user.TwoFactorEnabled);
				parameters.Add("@AccessFailedCount", user.AccessFailedCount);
				parameters.Add("@Email", user.Email);


				cn.Execute("AddUser", parameters, 
					commandType: CommandType.StoredProcedure);
			}
		}

		public void EditUser(UserItem user)
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				var parameters = new DynamicParameters();
				parameters.Add("@UserId", user.UserId);
				parameters.Add("@FirstName", user.FirstName);
				parameters.Add("@LastName", user.LastName);
				parameters.Add("@RoleId", user.RoleId);
				parameters.Add("@UserName", user.FirstName + " " + user.LastName);
				parameters.Add("@PasswordHash", user.PasswordHash);
				parameters.Add("@Email", user.Email);
				parameters.Add("@PhoneNumberConfirmed", user.PhoneNumberConfirmed);
				parameters.Add("@EmailConfirmed", user.EmailConfirmed);
				parameters.Add("@TwoFactorEnabled", user.TwoFactorEnabled);
				parameters.Add("@AccessFailedCount", user.AccessFailedCount);
				parameters.Add("@Email", user.Email);

				if (user.RoleId == "disabled")
				{
					parameters.Add("@LockOutEnabled", 1);
				}
				else
					parameters.Add("@LockOutEnabled", 0);

				cn.Execute("EditUser", parameters, commandType: CommandType.StoredProcedure);
			}
		}
			public void EditPassword(UserItem user)
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				var parameters = new DynamicParameters();
				parameters.Add("@UserId", user.UserId);
				parameters.Add("@PasswordHash", user.PasswordHash);

				cn.Execute("EditPassword", parameters, commandType: CommandType.StoredProcedure);
			}
		}
	}
}
