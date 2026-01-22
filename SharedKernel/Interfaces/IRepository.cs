using SharedKernel.Bases;

namespace SharedKernel.Interfaces;

public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}