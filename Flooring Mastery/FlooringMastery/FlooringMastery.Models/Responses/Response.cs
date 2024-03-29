﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Responses
{
	public class Response
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public string Date { get; set; }
		public List<Order> Orders { get; set; }
		public Order order { get; set; }
	}
}
