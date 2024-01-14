namespace CleanArchitecture.Domain.Interfaces;

public interface IUnitOfWork
{
    Task commit(CancellationToken cancellationToken);
}
