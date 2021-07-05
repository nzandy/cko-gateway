using System;
using Checkout.PaymentGateway.Models.Validators;
using NUnit.Framework;

namespace Checkout.PaymentGateway.Models.UnitTests.Validators
{
	[TestFixture]
	public class YearIsCurrentOrFutureTests
	{
		private YearIsCurrentOrFuture _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new YearIsCurrentOrFuture();
		}

		[Test]
		public void YearInPast_ShouldFailValidation()
		{
			Assert.That(_sut.IsValid(2019), Is.False);
		}

		[Test]
		public void CurrentYear_ShouldPassValidation()
		{
			var currentYear = DateTime.Now.Year;
			Assert.That(_sut.IsValid(currentYear), Is.True);
		}

		[Test]
		public void FutureYear_ShouldPassValidation()
		{
			var futureYear = DateTime.Now.Year + 1;
			Assert.That(_sut.IsValid(futureYear), Is.True);
		}
	}
}
