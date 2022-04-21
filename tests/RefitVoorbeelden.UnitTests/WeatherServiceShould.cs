using System.Threading.Tasks;
using Moq;
using RefitVoorbeelden.Core;
using Xunit;

namespace RefitVoorbeelden.UnitTests;

public class WeatherServiceShould
{
   [Fact]
   public async Task ReturnTheWeatherForTheRequestedLocation()
   {
     // ARRANGE
     var mockApi = new Mock<IOpenWeatherApi>();
     mockApi
         .Setup(with => with.WeatherForLocation(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
         .ReturnsAsync(new WeatherData {Location = "Test Location"});
     var weatherService = new WeatherService(mockApi.Object);

     // ACT
     var weather = await weatherService.GetWeatherForLocation("testlat", "testlong", "api-key");

     // ASSERT
     mockApi.Verify(apiCall => apiCall.WeatherForLocation(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
   }
}