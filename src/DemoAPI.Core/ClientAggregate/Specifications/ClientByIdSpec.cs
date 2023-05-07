using Ardalis.Specification;

namespace DemoAPI.Core.ClientAggregate.Specifications;
public class ClientByIdSpec : Specification<Client>, ISingleResultSpecification
{
  public ClientByIdSpec(int clientId)
  {
    Query
        .Where(client => client.Id == clientId);
  }
}
