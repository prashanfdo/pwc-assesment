using DemoAPI.Core.ClientAggregate;
using DemoAPI.SharedKernel.Interfaces;
using FastEndpoints;
using DemoAPI.Core.ClientAggregate.Specifications;

namespace DemoAPI.Web.Endpoints.ClientEndpoints;
public class GetById : Endpoint<GetClientByIdRequest, ClientRecord>
{
  private readonly IRepository<Client> _repository;

  public GetById(IRepository<Client> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Get(GetClientByIdRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("ClientEndpoints"));
  }
  public override async Task HandleAsync(GetClientByIdRequest request,
    CancellationToken cancellationToken)
  {
    var spec = new ClientByIdSpec(request.ClientId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var response = new ClientRecord(entity.Id, entity.Name, entity.ContactEmail, entity.DateJoinedAsCustomer);

    await SendAsync(response, cancellation: cancellationToken);
  }
}
