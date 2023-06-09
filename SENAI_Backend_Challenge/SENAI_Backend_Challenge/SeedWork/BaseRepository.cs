using Microsoft.EntityFrameworkCore;
using SENAI_Backend_Challenge.Contexts;

namespace SENAI_Backend_Challenge.SeedWork
{
    public abstract class BaseRepository<T> : IRepository<T> where T : AbstractDomain
    {
        protected SenaiContext _ctx;
        private DbSet<T> _entity;
        IUnitOfWork IRepository<T>.UnitOfWork => _ctx;

        protected BaseRepository(SenaiContext ctx)
        {
            _ctx = ctx;
            _entity = _ctx.Set<T>();
        }

        public async Task<T> CreateAsync(T objeto)
        {
            return await Task.FromResult(_entity.AddAsync(objeto).Result.Entity);
        }

        public async Task<bool> UpdateAsync(T objeto)
        {
            try
            {
                await Task.FromResult(_entity.Update(objeto));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T? GetById(long id) =>
            _entity.FirstOrDefault(x => x.Id == id);

        public async Task<List<T>> GetAllAsync() =>
            await _entity.ToListAsync();

        public bool Delete(T objeto)
        {
            try
            {
                _entity.Remove(objeto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
