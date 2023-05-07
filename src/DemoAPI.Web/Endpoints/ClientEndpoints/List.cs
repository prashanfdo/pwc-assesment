using DemoAPI.Core.ClientAggregate;
using DemoAPI.SharedKernel.Interfaces;
using FastEndpoints;

namespace DemoAPI.Web.Endpoints.ClientEndpoints;
public class List : EndpointWithoutRequest<ClientListResponse>
{
  private readonly IRepository<Client> _repository;

  public List(IRepository<Client> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Get("/Clients");
    AllowAnonymous();
    Options(x => x
      .WithTags("ClientEndpoints"));
  }
  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var clients = await _repository.ListAsync(cancellationToken);
    var response = new ClientListResponse()
    {
      Clients = clients
        .Select(client => new ClientRecord(client.Id, client.Name, client.ContactEmail, client.DateJoinedAsCustomer))
        .ToList()
    };

    await SendAsync(response, cancellation: cancellationToken);
  }
}
