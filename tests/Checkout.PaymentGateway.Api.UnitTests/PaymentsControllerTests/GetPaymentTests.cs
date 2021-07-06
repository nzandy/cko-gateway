using System;
using System.Threading.Tasks;
using Checkout.PaymentGateway.Api.Controllers;
using Checkout.PaymentGateway.Models.Responses;
using Checkout.PaymentGateway.Services;
using KellermanSoftware.CompareNetObjects;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Checkout.PaymentGateway.Api.UnitTests.PaymentsControllerTests
{
	public class GetPaymentTests
	{
		private PaymentsController _sut;
		private Mock<IPaymentService> _paymentServiceMock;
		private const int MerchantId = 1;

		[SetUp]
		public void Setup()
		{
			_paymentServiceMock = new Mock<IPaymentService>();
			_sut = new PaymentsController(_paymentServiceMock.Object);
		}

		[Test]
		public async Task ShouldReturnExpectedDto_WhenDtoExistsMatchingId()
		{
			// Arrange.
			var paymentId = Guid.NewGuid();
			var paymentResponseDto = new GetPaymentResponseDto
			{
				Amount = 20,
				Currency = "NZD",
				ExpiryMonth = 12,
				ExpiryYear = 2099,
				Id = paymentId,
				MaskedCardNumber = "4444********1111",
				MerchantId = MerchantId
			};
			_paymentServiceMock.Setup(paymentService => paymentService.GetPaymentAsync(paymentId, MerchantId))
				.ReturnsAsync(paymentResponseDto);

			
			// Act.
			var response = (OkObjectResult) await _sut.GetPayment(paymentId, MerchantId);
			var actualResponseDto = (GetPaymentResponseDto) response.Value;
			
			
			// Assert.
			Assert.That(response, Is.Not.Null);
			Assert.That(actualResponseDto, Is.Not.Null);
			var compareLogic = new CompareLogic();
			var result = compareLogic.Compare(paymentResponseDto, actualResponseDto);
			Assert.That(result.AreEqual);
		}

		[Test]
		public async Task ShouldReturn404_WhenNoPaymentFoundMatchingId()
		{
			// Arrange.
			var paymentId = Guid.NewGuid();

			_paymentServiceMock.Setup(paymentService => paymentService.GetPaymentAsync(paymentId, MerchantId))
				.ReturnsAsync((GetPaymentResponseDto)null);


			// Act.
			var response = await _sut.GetPayment(paymentId, MerchantId);

			// Assert.
			Assert.That(response, Is.TypeOf<NotFoundResult>());
		}
	}
}