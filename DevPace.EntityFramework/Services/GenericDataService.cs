using DevPace.Domain.Models.Abstract;
using DevPace.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace DevPace.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : AbstractBaseEntity
    {
        private readonly DevPaceDbContextOptionsFactory _contextFactory;

        public GenericDataService(DevPaceDbContextOptionsFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            await using DevPaceDbContext context = _contextFactory.CreateDbContext();

            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            await using DevPaceDbContext context = _contextFactory.CreateDbContext();
            return await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await using DevPaceDbContext context = _contextFactory.CreateDbContext();
            var createdEntity = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<T> UpdateAsync(long id, T entity)
        {
            await using DevPaceDbContext context = _contextFactory.CreateDbContext();
            entity.Id = id;

            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            await using DevPaceDbContext context = _contextFactory.CreateDbContext();
            var entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity != null) context.Set<T>().Remove(entity);
            else return false;

            await context.SaveChangesAsync();

            return true;
        }
    }
}
