using DemoAPI.Core.ClientAggregate;
using Xunit;

namespace DemoAPI.IntegrationTests.Data;
public class EfRepositoryAdd : BaseEfRepoTestFixture
{
  [Fact]
  public async Task AddsClientAndSetsId()
  {
    var testClientName = "testClient";
    var testClientContactEmail = "testClient@test.com";
    var testClientDatejoinedAsCustomer = new DateTime(2020, 1, 1);
    var repository = GetRepository();
    var client = new Client(testClientName, testClientContactEmail, testClientDatejoinedAsCustomer);

    await repository.AddAsync(client);

    var newClient = (await repository.ListAsync())
                    .FirstOrDefault();

    Assert.Equal(testClientName, newClient?.Name);
    Assert.Equal(testClientContactEmail, newClient?.ContactEmail);
    Assert.Equal(testClientDatejoinedAsCustomer, newClient?.DateJoinedAsCustomer);
    Assert.True(newClient?.Id > 0);
  }
}
