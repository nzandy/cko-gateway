﻿using System.ComponentModel.DataAnnotations;

namespace Checkout.PaymentGateway.Models
{
	public class CardDetails
	{
		[Required]
		public string CardNumber { get; set; }
		[Required]
		public string ExpiryYear { get; set; }
		[Required]
		public string ExpiryMonth { get; set; }
	}
}
