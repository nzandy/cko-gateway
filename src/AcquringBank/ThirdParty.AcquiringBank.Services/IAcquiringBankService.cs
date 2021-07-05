using System.Threading.Tasks;
using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Models.Requests;
using Checkout.Shared.Models;

namespace Checkout.AcquiringBank.Services
{
	public interface IAcquiringBankService
	{
		public Task<PaymentResult> ProcessPaymentAsync(SubmitPaymentRequestDto payment);
	}
}
