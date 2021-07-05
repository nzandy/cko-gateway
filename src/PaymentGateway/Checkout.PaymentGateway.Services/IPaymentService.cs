using System;
using System.Threading.Tasks;
using Checkout.PaymentGateway.Models.Requests;
using Checkout.PaymentGateway.Models.Responses;

namespace Checkout.PaymentGateway.Services
{
	public interface IPaymentService
	{
		public Task<SubmitPaymentResponseDto> AttemptPaymentAsync(SubmitPaymentRequestDto paymentRequest);
		public Task<GetPaymentResponseDto> GetPaymentAsync(Guid paymentId);
	}
}
