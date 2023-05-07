using DemoAPI.Core.ClientAggregate;
using DemoAPI.Core.Services;
using DemoAPI.SharedKernel.Interfaces;
using MediatR;
using Moq;
using Xunit;

namespace DemoAPI.UnitTests.Core.Services;
public class DeleteClientService_DeleteClient
{
  private readonly Mock<IRepository<Client>> _mockRepo = new Mock<IRepository<Client>>();
  private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
  private readonly DeleteClientService _service;

  public DeleteClientService_DeleteClient()
  {
    _service = new DeleteClientService(_mockRepo.Object, _mockMediator.Object);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindClient()
  {
    var result = await _service.DeleteClient(0);

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}
