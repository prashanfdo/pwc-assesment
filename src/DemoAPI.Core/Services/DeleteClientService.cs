using Ardalis.Result;
using DemoAPI.Core.ClientAggregate;
using DemoAPI.Core.ClientAggregate.Events;
using DemoAPI.Core.Interfaces;
using DemoAPI.SharedKernel.Interfaces;
using MediatR;

namespace DemoAPI.Core.Services;
public class DeleteClientService : IDeleteClientService
{
  private readonly IRepository<Client> _repository;
  private readonly IMediator _mediator;

  public DeleteClientService(IRepository<Client> repository, IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }

  public async Task<Result> DeleteClient(int clientId)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(clientId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new ClientDeletedEvent(clientId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
