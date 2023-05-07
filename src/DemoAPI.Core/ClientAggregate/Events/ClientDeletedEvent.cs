using DemoAPI.SharedKernel;

namespace DemoAPI.Core.ClientAggregate.Events;
public class ClientDeletedEvent : DomainEventBase
{
  public int ClientId { get; set; }

  public ClientDeletedEvent(int clientId)
  {
    ClientId = clientId;
  }
}
