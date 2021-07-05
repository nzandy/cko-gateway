using System;
using System.Threading.Tasks;
using Checkout.PaymentGateway.Api.Controllers;
using Checkout.PaymentGateway.Models.Requests;
using Checkout.PaymentGateway.Models.Responses;
using Checkout.PaymentGateway.Services;
using Checkout.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Checkout.PaymentGateway.Api.UnitTests.PaymentsControllerTests
{
	public class Tests
	{
		private PaymentsController _sut;
		private Mock<IPaymentService> _paymentServiceMock;

		[SetUp]
		public void Setup()
		{
			_paymentServiceMock = new Mock<IPaymentService>();
			_sut = new PaymentsController(_paymentServiceMock.Object);
		}

		[Test]
		public async Task Should_Return_201Response_WithCorrect_ID_WhenPaymentProcessedSuccessfully()
		{
			// Arrange.
			var request = new SubmitPaymentRequestDto();
			var response = new SubmitPaymentResponseDto
			{
				PaymentId = Guid.NewGuid(),
				PaymentResult = PaymentResult.Succeeded
			};
			_paymentServiceMock.Setup(paymentService => paymentService.ProcessPaymentAsync(request)).ReturnsAsync(response);


			// Act.
			var actualResponse = (CreatedAtActionResult)await _sut.ProcessPayment(request);
			var responseModel = (SubmitPaymentResponseDto) actualResponse.Value;


			// Assert.
			Assert.That(actualResponse, Is.Not.Null);
			Assert.That(responseModel, Is.Not.Null);
			Assert.That(responseModel.PaymentId, Is.EqualTo(response.PaymentId));
			Assert.That(responseModel.PaymentResult, Is.EqualTo(response.PaymentResult));
		}
	}
}