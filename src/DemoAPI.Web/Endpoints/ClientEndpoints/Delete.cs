using Ardalis.Result;
using DemoAPI.Core.Interfaces;
using FastEndpoints;

namespace DemoAPI.Web.Endpoints.ClientEndpoints;
public class Delete : Endpoint<DeleteClientRequest>
{

  private readonly IDeleteClientService _deleteClientService;

  public Delete(IDeleteClientService service)
  {
    _deleteClientService = service;
  }

  public override void Configure()
  {
    Delete(DeleteClientRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("ClientEndpoints"));
  }
  public override async Task HandleAsync(
    DeleteClientRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _deleteClientService.DeleteClient(request.ClientId);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    await SendNoContentAsync(cancellationToken);
  }
}
