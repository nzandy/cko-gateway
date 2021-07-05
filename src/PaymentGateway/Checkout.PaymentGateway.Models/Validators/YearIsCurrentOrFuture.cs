using System;
using System.ComponentModel.DataAnnotations;

namespace Checkout.PaymentGateway.Models.Validators
{
	public class YearIsCurrentOrFuture : ValidationAttribute
	{
			protected override ValidationResult IsValid(object value, ValidationContext validationContext)
			{
				var yearFromRequest = (int)value;
				var currentYear = DateTime.Now.Year;
				return yearFromRequest < currentYear ? new ValidationResult("Card expiry year is in the past.") : ValidationResult.Success;
			}
	}
}
