using System;
using System.Threading.Tasks;
using Checkout.PaymentGateway.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Checkout.PaymentGateway.Services;

namespace Checkout.PaymentGateway.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PaymentsController : ControllerBase
	{
		private readonly IPaymentService _paymentService;

		public PaymentsController(IPaymentService paymentService)
		{
			_paymentService = paymentService;
		}

		[HttpPost]
		public async Task<IActionResult> ProcessPayment([FromBody]SubmitPaymentRequestDto paymentRequest)
		{
			var result = await _paymentService.ProcessPaymentAsync(paymentRequest);
			return CreatedAtAction(nameof(GetPayment), result);
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
