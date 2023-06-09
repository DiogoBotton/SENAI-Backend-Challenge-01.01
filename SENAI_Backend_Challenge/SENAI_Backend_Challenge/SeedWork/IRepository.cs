namespace SENAI_Backend_Challenge.SeedWork
{
    public interface IRepository<T> where T : AbstractDomain
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> CreateAsync(T objeto);
        Task<bool> UpdateAsync(T objeto);
        Task<List<T>> GetAllAsync();
        bool Delete(T objeto);
        T? GetById(long id);
    }
}
