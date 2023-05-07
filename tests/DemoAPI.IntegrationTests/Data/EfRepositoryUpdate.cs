using DemoAPI.Core.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DemoAPI.IntegrationTests.Data;
public class EfRepositoryUpdate : BaseEfRepoTestFixture
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a client
    var repository = GetRepository();
    var intialClientName = "testClient";
    var intialClientContactEmail = "testClient@test.com";
    var intialClientDatejoinedAsCustomer = new DateTime(2020, 1, 1); 
    var client = new Client(intialClientName, intialClientContactEmail, intialClientDatejoinedAsCustomer);

    await repository.AddAsync(client);

    // detach the item so we get a different instance
    _dbContext.Entry(client).State = EntityState.Detached;

    // fetch the item and update its title
    var newClient = (await repository.ListAsync())
        .FirstOrDefault(client => client.Name == intialClientName);
    if (newClient == null)
    {
      Assert.NotNull(newClient);
      return;
    }
    Assert.NotSame(client, newClient);
    var newName = Guid.NewGuid().ToString();
    newClient.UpdateName(newName);

    // Update the item
    await repository.UpdateAsync(newClient);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync())
        .FirstOrDefault(client => client.Name == newName);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(client.Name, updatedItem?.Name);
    Assert.Equal(client.ContactEmail, updatedItem?.ContactEmail);
    Assert.Equal(client.DateJoinedAsCustomer, updatedItem?.DateJoinedAsCustomer);
    Assert.Equal(newClient.Id, updatedItem?.Id);
  }
}
