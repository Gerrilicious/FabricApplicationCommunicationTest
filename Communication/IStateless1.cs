using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Communication
{
	public interface IStateless1 : IService
	{
		Task<WeatherForecast[]> GetAsync();
	}
}
