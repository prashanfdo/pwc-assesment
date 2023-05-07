using Ardalis.Specification;

namespace DemoAPI.SharedKernel.Interfaces;
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
