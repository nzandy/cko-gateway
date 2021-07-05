﻿using System;
using Checkout.Shared.Models;

namespace Checkout.PaymentGateway.Domain
{
	public class Payment : MerchantEntity
	{
		public Guid CardDetailsId { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; }
		public PaymentResult Result { get; set; }
	}
}
