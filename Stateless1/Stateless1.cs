using System.Fabric;
using Communication;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

[assembly: FabricTransportServiceRemotingProvider(RemotingListenerVersion = RemotingListenerVersion.V2, RemotingClientVersion = RemotingClientVersion.V2)]

namespace Stateless1;

/// <summary>
///     An instance of this class is created for each service instance by the Service Fabric runtime.
/// </summary>
internal sealed class Stateless1 : StatelessService, IStateless1
{
	private static readonly string[] Summaries =
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	public Stateless1(StatelessServiceContext context)
		: base(context)
	{
	}

	public async Task<WeatherForecast[]> GetAsync()
	{
		var rng = new Random();
		return Enumerable.Range(1, 5)
		                 .Select(index => new WeatherForecast
		                 {
			                 Date = DateTime.Now.AddDays(index),
			                 TemperatureC = rng.Next(-20, 55),
			                 Summary = Summaries[rng.Next(Summaries.Length)]
		                 })
		                 .ToArray();
	}

    /// <summary>
    ///     Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
    /// </summary>
    /// <returns>A collection of listeners.</returns>
    protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
	{
		return this.CreateServiceRemotingInstanceListeners();
	}

    /// <summary>
    ///     This is the main entry point for your service instance.
    /// </summary>
    /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service instance.</param>
    protected override async Task RunAsync(CancellationToken cancellationToken)
	{
		//// TODO: Replace the following sample code with your own logic 
		////       or remove this RunAsync override if it's not needed in your service.

		//long iterations = 0;

		//while (true)
		//{
		//	cancellationToken.ThrowIfCancellationRequested();

		//	ServiceEventSource.Current.ServiceMessage(Context, "Working-{0}", ++iterations);

		//	await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
		//}
	}
}
