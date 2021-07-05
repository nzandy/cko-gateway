using System;
using System.Threading.Tasks;
using Checkout.PaymentGateway.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Checkout.PaymentGateway.Services;
using Checkout.Shared.Models;

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

			return result.PaymentResult switch
			{
				PaymentResult.Succeeded => CreatedAtAction(nameof(GetPayment), new { id = result.PaymentId.Value },
					result),
				PaymentResult.Declined => BadRequest(),
				PaymentResult.Pending => BadRequest(),
				_ => throw new ArgumentOutOfRangeException()
			};

		}

		[HttpGet]
		[Route("{id:guid}")]
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
