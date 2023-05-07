using DemoAPI.Core.ClientAggregate;
using Xunit;

namespace DemoAPI.UnitTests.Core.ClientAggregate;
public class ClientConstructor
{
  private readonly string _testName = "test name";
  private readonly string _testContactEmail = "test@test.com";
  private readonly DateTime _testDateJoinedAsCustomer = new DateTime(2020,1,1);
  private Client? _testClient;

  private Client CreateClient()
  {
    return new Client(_testName, _testContactEmail, _testDateJoinedAsCustomer);
  }

  [Fact]
  public void InitializesName()
  {
    _testClient = CreateClient();

    Assert.Equal(_testName, _testClient.Name);
    Assert.Equal(_testContactEmail, _testClient.ContactEmail);
    Assert.Equal(_testDateJoinedAsCustomer, _testClient.DateJoinedAsCustomer);
  }
}
