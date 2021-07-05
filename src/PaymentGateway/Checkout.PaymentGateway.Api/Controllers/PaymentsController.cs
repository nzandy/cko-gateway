﻿using System;
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

		/// <summary>
		/// Attempts to process a payment with the cards vendor.
		/// </summary>
		/// <param name="paymentRequest">Details required to process payment.</param>
		/// <remarks>
		/// Sample request:
		///
		///     POST /payments
		///		{
		///			"amount": 20.0,
		///			"currency": "AUD",
		///			"merchantId": 2
		///			"cardDetails": {
		///				"cardNumber": "4621977792064149",
		///				"expiryYear": 2021,
		///				"expiryMonth": 12
		///			}
		///		}
		/// </remarks>
		/// <returns>PaymentId and Payment Result.</returns>
		[HttpPost]
		public async Task<IActionResult> ProcessPayment([FromBody]SubmitPaymentRequestDto paymentRequest)
		{
			var result = await _paymentService.ProcessPaymentAsync(paymentRequest);
			return CreatedAtAction(nameof(GetPayment), new {id = result.PaymentId}, result);
		}

		/// <summary>
		/// Fetch payment details by ID.
		/// </summary>
		/// <param name="id"></param>
		/// <remarks>
		/// Sample request:
		///     GET /payments/14992255-f789-4d89-b7a9-34f6a1ccb02a
		/// </remarks>
		/// <returns>json containing payment information.</returns>
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
