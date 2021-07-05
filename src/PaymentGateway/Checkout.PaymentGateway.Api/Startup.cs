using Checkout.AcquiringBank.Services;
using Checkout.PaymentGateway.DataAccess;
using Checkout.PaymentGateway.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Checkout.PaymentGateway.Services;

namespace Checkout.PaymentGateway.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Checkout.PaymentGateway.Api", Version = "v1" });
			});

			services.AddScoped<IPaymentService, PaymentService>();
			services.AddScoped<IAcquiringBankService, MockAcquiringBankService>();
			services.AddSingleton<IGenericRepository<CardDetails>, GenericRepository<CardDetails>>();
			services.AddSingleton<IGenericRepository<Payment>, GenericRepository<Payment>>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Checkout.PaymentGateway.Api v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
