using DemoAPI.Core.ClientAggregate;
using DemoAPI.SharedKernel.Interfaces;
using FastEndpoints;
using Mapster;

namespace DemoAPI.Web.Endpoints.ClientEndpoints;
public class Create : Endpoint<CreateClientRequest, CreateClientResponse>
{
  private readonly IRepository<Client> _repository;

  public Create(IRepository<Client> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Post(CreateClientRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("ClientEndpoints"));
  }
  public override async Task HandleAsync(
    CreateClientRequest request,
    CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      ThrowError("Name is required");
    }
    if (request.ContactEmail == null)
    {
      ThrowError("ContactEmail is required");
    }
    if (request.DateJoinedAsCustomer == null)
    {
      ThrowError("ContactEmail is required");
    }

    var newClient = new Client(request.Name, request.ContactEmail, request.DateJoinedAsCustomer.Value);
    var createdItem = await _repository.AddAsync(newClient, cancellationToken);
    var response = createdItem.Adapt<CreateClientResponse>();

    await SendAsync(response, cancellation: cancellationToken);
  }
}
