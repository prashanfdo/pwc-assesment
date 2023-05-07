using DemoAPI.Core.ClientAggregate;
using DemoAPI.SharedKernel.Interfaces;
using FastEndpoints;

namespace DemoAPI.Web.Endpoints.ClientEndpoints;
public class Update : Endpoint<UpdateClientRequest, UpdateClientResponse>
{
  private readonly IRepository<Client> _repository;

  public Update(IRepository<Client> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Put(CreateClientRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("ClientEndpoints"));
  }
  public override async Task HandleAsync(
    UpdateClientRequest request,
    CancellationToken cancellationToken)
  { 
    var existingClient = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (existingClient == null)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if(request.Name != null)
      existingClient.UpdateName(request.Name);
    if(request.ContactEmail != null)
      existingClient.UpdateContactEmail(request.ContactEmail);
    if (request.DateJoinedAsCustomer != null)
      existingClient.UpdateDateJoinedAsCustomer(request.DateJoinedAsCustomer.Value);

    await _repository.UpdateAsync(existingClient, cancellationToken);

    var response = new UpdateClientResponse(
        client: new ClientRecord(existingClient.Id, existingClient.Name, existingClient.ContactEmail, existingClient.DateJoinedAsCustomer)
    );

    await SendAsync(response, cancellation: cancellationToken);
  }
}
