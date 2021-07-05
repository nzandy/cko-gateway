using System.ComponentModel.DataAnnotations;
using System.Linq;
using ISO._4217;

namespace Checkout.PaymentGateway.Models.Validators
{
	public class Iso4217CurrencyCode : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var currencyCodeFromRequest = (string)value;
			var codeIsValid = CurrencyCodesResolver.Codes.Any(code => code.Code == currencyCodeFromRequest);
			return codeIsValid ?  ValidationResult.Success : new ValidationResult("Currency code must be ISO-4217 compliant");
		}

	}
}