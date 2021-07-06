using System;
using System.Threading.Tasks;
using Checkout.AcquiringBank.Services;
using Checkout.PaymentGateway.DataAccess;
using Checkout.PaymentGateway.DataAccess.Entities;
using Checkout.Shared.Models;
using Moq;
using NUnit.Framework;

namespace Checkout.PaymentGateway.Services.UnitTests
{
	public class GetPaymentAsyncTests
	{
		private PaymentService _sut;
		private Mock<IEntityRepository<CardDetails>> _cardDetailsRepoMock;
		private Mock<IEntityRepository<Payment>> _paymentRepoMock;
		private Mock<IAcquiringBankService> _acquiringBankServiceMock;
		private const int MerchantId = 1;

		[SetUp]
		public void Setup()
		{
			_cardDetailsRepoMock = new Mock<IEntityRepository<CardDetails>>();
			_paymentRepoMock = new Mock<IEntityRepository<Payment>>();
			_acquiringBankServiceMock = new Mock<IAcquiringBankService>();

			_sut = new PaymentService(_cardDetailsRepoMock.Object, _paymentRepoMock.Object,
				_acquiringBankServiceMock.Object);
		}

		[Test]
		public async Task ShouldReturnExpectedModel_WhenPaymentIdAndMerchantIdMatch()
		{
			// Arrange
			var cardDetails = GetTestCardDetails();
			var payment = GetTestPayment(cardDetails.Id);

			_paymentRepoMock.Setup(repo => repo.GetByIdAsync(payment.Id)).ReturnsAsync(payment);
			_cardDetailsRepoMock.Setup(repo => repo.GetByIdAsync(cardDetails.Id)).ReturnsAsync(cardDetails);


			// Act
			var result = await _sut.GetPaymentAsync(payment.Id, MerchantId);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.MerchantId, Is.EqualTo(MerchantId));
			Assert.That(result.Currency, Is.EqualTo(payment.Currency));
			Assert.That(result.ExpiryMonth, Is.EqualTo(cardDetails.ExpiryMonth));
			Assert.That(result.ExpiryYear, Is.EqualTo(cardDetails.ExpiryYear));
			Assert.That(result.Id, Is.EqualTo(payment.Id));
			Assert.That(result.Result, Is.EqualTo(PaymentResult.Succeeded));
		}

		[Test]
		public async Task ShouldReturnNull_WhenPaymentNotFound()
		{
			// Arrange
			var paymentId = Guid.NewGuid();
			_paymentRepoMock.Setup(repo => repo.GetByIdAsync(paymentId)).ReturnsAsync((Payment) null);

			// Act
			var result = await _sut.GetPaymentAsync(paymentId, MerchantId);

			// Assert.
			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task ShouldReturnNull_WhenMerchantIdDoesNotMatch()
		{
			// Arrange
			var cardDetails = GetTestCardDetails();
			var payment = GetTestPayment(cardDetails.Id);

			_paymentRepoMock.Setup(repo => repo.GetByIdAsync(payment.Id)).ReturnsAsync(payment);

			// Act
			var result = await _sut.GetPaymentAsync(payment.Id, 2);

			// Assert.
			Assert.That(result, Is.Null);
		}

		private CardDetails GetTestCardDetails()
		{
			return new CardDetails
			{
				Id = Guid.NewGuid(),
				CardNumber = "378282246310005",
				ExpiryMonth = 12,
				ExpiryYear = DateTime.Now.Year + 1
			};
		}

		private Payment GetTestPayment(Guid cardDetailsId)
		{
			return new Payment
			{
				Id = Guid.NewGuid(),
				Amount = 20,
				CardDetailsId = cardDetailsId,
				Currency = "NZD",
				MerchantId = MerchantId,
				Result = PaymentResult.Succeeded
			};
		}
	}
}