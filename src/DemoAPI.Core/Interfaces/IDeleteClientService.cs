using Ardalis.Result;

namespace DemoAPI.Core.Interfaces;
public interface IDeleteClientService
{
  public Task<Result> DeleteClient(int clientId);
}
