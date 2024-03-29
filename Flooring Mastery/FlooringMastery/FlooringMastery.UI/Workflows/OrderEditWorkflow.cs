﻿using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
	public class OrderEditWorkflow
	{

		public void Execute()
		{
			OrderManager manager = OrderManagerFactory.Create();
			Response response;
			int orderNumber;
			string orderDate;

			while (true)
			{
				Console.Clear();
				Console.WriteLine("Lookup an order to edit");
				ConsoleIO.DividingLine();
				Console.WriteLine("Enter a date (dd/mm/yyyy): ");
				orderDate = Console.ReadLine();
				bool validDate = ConsoleIO.checkDate(orderDate);


				Console.WriteLine("Enter an order number: ");
				bool numSuccess = int.TryParse(Console.ReadLine(), out orderNumber);

				if (!numSuccess || orderNumber <= 0)
					Console.WriteLine("Please enter a valid order number.");
				if (!validDate)
					Console.WriteLine("Please enter a valid date - mm/dd/yyyy");

				if (numSuccess && orderNumber >= 1 && validDate)
				{
					response = manager.LookupOrder(orderDate);
					if(response.Success && orderNumber <= response.Orders.Count)
						break;
					response.Message = "The order number dooes not exist.";

					Console.WriteLine("An error occurred: ");
					Console.WriteLine(response.Message);
				}

				Console.WriteLine("Press any key to continue");
				Console.ReadKey();
			}

			if (response.Success && orderNumber <= response.Orders.Count)
			{
				orderNumber--;
				bool confirmAddEntry;

				while (true)
				{
					response.Success = false;

					response = manager.LookupOrder(orderDate);
					response.order = response.Orders[orderNumber];
					response.order.CustomerName = ConsoleIO.OrderEditPrompt("customer name", orderNumber, response);
					response.order.State = ConsoleIO.OrderEditPrompt("state", orderNumber, response);
					response.order.ProductType = ConsoleIO.OrderEditPrompt("product type", orderNumber, response);
					string area = ConsoleIO.OrderEditPrompt("area", orderNumber, response);
					decimal decimalArea;
					bool isValidArea = Decimal.TryParse(area, out decimalArea);

					if (isValidArea)
					{
						response.order.Area = decimalArea;
						response.order = ExpenseCalculator.Calculator(response);
						response = OrderEditRules.UserEditInput(response);
					}
					else { Console.WriteLine("Please enter a number for the area."); response.Success = false; } 

					if (response.Success)
					{
						ConsoleIO.DisplayOrderSummaryDetails(response.order, orderDate);
						confirmAddEntry = ConsoleIO.ConfirmAddEntry();
						if (confirmAddEntry)
						{
							manager.EditOrder(response.Orders, orderNumber);
							break;
						}

						if (!confirmAddEntry)
							break;
					}

					else { Console.WriteLine(response.Message); }
					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
					Console.Clear();

				}
			}

			else
			{
				Console.WriteLine("An error occurred: ");
				Console.WriteLine(response.Message);
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
			}

		}

		}
	}

