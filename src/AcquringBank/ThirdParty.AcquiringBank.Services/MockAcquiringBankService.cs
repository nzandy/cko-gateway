using System.Threading.Tasks;
using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Models.Requests;
using Checkout.Shared.Models;

namespace Checkout.AcquiringBank.Services
{
	public class MockAcquiringBankService : IAcquiringBankService
	{
		public async Task<PaymentResult> ProcessPaymentAsync(SubmitPaymentRequestDto payment)
		{
			await Task.Delay(200);
			return payment.Amount > 100 ? PaymentResult.Declined : PaymentResult.Succeeded;
		}
	}
}
