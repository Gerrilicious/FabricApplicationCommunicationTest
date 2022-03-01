using System;
using System.Threading.Tasks;
using Communication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IStateless1 _stateless1;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IStateless1 stateless1)
		{
			_logger = logger;
			_stateless1 = stateless1;
		}

		[HttpGet]
		public async Task<WeatherForecast[]> Get()
		{
			IStateless1 helloWorldClient = ServiceProxy.Create<IStateless1>(new Uri("fabric:/FabricServicesApplication/Stateless1"));

			var message = await helloWorldClient.GetAsync();
			return await _stateless1.GetAsync();
		}
	}
}
