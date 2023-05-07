using DemoAPI.Core.ClientAggregate;
using Xunit;

namespace DemoAPI.IntegrationTests.Data;
public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a client
    var repository = GetRepository();
    var testClientName = "testClient";
    var testClientContactEmail = "testClient@test.com";
    var testClientDatejoinedAsCustomer = new DateTime(2020, 1, 1);
    var client = new Client(testClientName, testClientContactEmail, testClientDatejoinedAsCustomer);
    await repository.AddAsync(client);

    // delete the item
    await repository.DeleteAsync(client);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        client => client.Name == testClientName);
  }
}
