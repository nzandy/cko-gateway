using System;
using System.Threading.Tasks;
using Checkout.PaymentGateway.Models.Requests;
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

		public PaymentsController(IPaymentService paymentService, ILogger<PaymentsController> logger)
		{
			_paymentService = paymentService;
			_logger = logger;
		}

		[HttpPost]
		public async Task<IActionResult> SubmitPayment([FromBody]SubmitPaymentRequestDto paymentRequest)
		{
			var result = await _paymentService.AttemptPaymentAsync(paymentRequest);
			return CreatedAtAction(nameof(GetPayment), new { id = result.PaymentId }, result);
		}

		[HttpGet]
		[Route("[controller]/{id:guid}")]
		public async Task<IActionResult> GetPayment(Guid id)
		{
			var result = await _paymentService.GetPaymentAsync(id);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}
	}
}
