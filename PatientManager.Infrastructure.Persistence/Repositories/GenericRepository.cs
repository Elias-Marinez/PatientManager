
using Microsoft.EntityFrameworkCore;
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Infrastructure.Persistence.Contexts;

namespace PatientManager.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly ApplicationContext _dbContext;

        public GenericRepository(ApplicationContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public virtual async Task AddAsync(Entity entity)
        {
            await _dbContext.Set<Entity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task UpdateAsync(Entity entity, int id)
        {
            var entry = await _dbContext.Set<Entity>().FindAsync(id);

            _dbContext.Entry(entry).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entry = await _dbContext.Set<Entity>().FindAsync(id);
            _dbContext.Set<Entity>().Remove(entry);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<Entity>> GetAllAsync()
        {
            return await _dbContext.Set<Entity>().ToListAsync();
        }

        public virtual async Task<List<Entity>> GetAllWithIncludeAsync()
        {
            var entityProperties = _dbContext.Model.FindEntityType(typeof(Entity)).GetNavigations();

            var query = _dbContext.Set<Entity>().AsQueryable();

            foreach (var property in entityProperties)
            {
                query = query.Include(property.Name);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<Entity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Entity>().FindAsync(id);
        }
    }
}
