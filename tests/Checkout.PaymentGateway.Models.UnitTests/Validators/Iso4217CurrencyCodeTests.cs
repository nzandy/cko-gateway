using Checkout.PaymentGateway.Models.Validators;
using NUnit.Framework;

namespace Checkout.PaymentGateway.Models.UnitTests.Validators
{
	[TestFixture]
	public class Iso4217CurrencyCodeTests
	{
		private Iso4217CurrencyCode _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new Iso4217CurrencyCode();
		}

		[Test]
		public void InvalidCurrencyCode_ShouldFailValidation()
		{
			Assert.That(_sut.IsValid("GBD"), Is.False);
		}

		[Test]
		public void ValidCurrencyCode_ShouldPassValidation()
		{
			Assert.That(_sut.IsValid("GBP"), Is.True);
		}
	}
}
