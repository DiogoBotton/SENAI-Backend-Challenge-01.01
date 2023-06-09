namespace SENAI_Backend_Challenge.SeedWork
{
    public interface IUnitOfWork
    {
        Task SaveDbChanges(CancellationToken cancellationToken = default(CancellationToken));
    }
}
