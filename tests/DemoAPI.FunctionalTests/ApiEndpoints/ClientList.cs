using Ardalis.HttpClientTestExtensions;
using DemoAPI.Web;
using DemoAPI.Web.Endpoints.ClientEndpoints;
using Xunit;

namespace DemoAPI.FunctionalTests.ApiEndpoints;
[Collection("Sequential")]
public class ClientList : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  public ClientList(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsTwoClients()
  {
    var result = await _client.GetAndDeserializeAsync<ClientListResponse>("/api/Clients");

    Assert.Equal(2, result.Clients.Count);
    Assert.Contains(result.Clients, i => i.Name == SeedData.Client1.Name);
    Assert.Contains(result.Clients, i => i.Name == SeedData.Client2.Name);
  }
}
