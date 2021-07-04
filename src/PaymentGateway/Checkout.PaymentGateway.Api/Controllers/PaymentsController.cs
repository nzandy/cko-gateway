using Checkout.PaymentGateway.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Checkout.PaymentGateway.Services;

namespace Checkout.PaymentGateway.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PaymentsController : ControllerBase
	{
		private readonly ILogger<PaymentsController> _logger;
		private readonly IPaymentService _paymentService;

		public PaymentsController(ILogger<PaymentsController> logger)
		{
			_logger = logger;
		}

		[HttpPost]
		public IActionResult SubmitPayment([FromBody]PaymentRequest paymentRequest)
		{
			_paymentService.AttemptPayment(paymentRequest);
			return Ok();
		}
	}
}
