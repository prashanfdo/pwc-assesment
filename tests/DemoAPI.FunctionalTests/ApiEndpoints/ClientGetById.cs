using Ardalis.HttpClientTestExtensions;
using DemoAPI.Web;
using DemoAPI.Web.Endpoints.ClientEndpoints;
using Xunit;

namespace DemoAPI.FunctionalTests.ApiEndpoints;
[Collection("Sequential")]
public class ClientGetById : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  public ClientGetById(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsSeedClientGivenId1()
  {
    var result = await _client.GetAndDeserializeAsync<ClientRecord>($"/api{GetClientByIdRequest.BuildRoute(1)}");

    Assert.Equal(1, result.Id);
    Assert.Equal(SeedData.Client1.Name, result.Name);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId0()
  {
    string route = GetClientByIdRequest.BuildRoute(0);
    _ = await _client.GetAndEnsureNotFoundAsync($"/api{route}");
  }
}
