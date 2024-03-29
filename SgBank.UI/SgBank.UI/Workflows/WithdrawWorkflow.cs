﻿using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgBank.UI.Workflows
{
	public class WithdrawWorkflow
	{
		public void Execute()
		{
			Console.Clear();

			AccountManager accountManager = AccountManagerFactory.Create();

			Console.WriteLine("Enter an account number: ");
			string accountNumber = Console.ReadLine();

			Console.Write("Enter a withdrawal amount: ");
			decimal amount = decimal.Parse(Console.ReadLine());

			AccountWithdrawResponse response = accountManager.Withdraw(accountNumber, amount);

			if (response.Success)
			{
				Console.WriteLine("Withdrawal completed!");
				Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
				Console.WriteLine($"Old balance: {response.OldBalance:c}");
				Console.WriteLine($"Amount Withdrawn: {response.Amount:c}");
				Console.WriteLine($"New Balance: ${response.Account.Balance}");

			}
			else { Console.WriteLine("An error occured: "); Console.WriteLine(response.Message); }

			Console.WriteLine("Press any key to continue...");
			 Console.ReadKey();
		}
	}
}
