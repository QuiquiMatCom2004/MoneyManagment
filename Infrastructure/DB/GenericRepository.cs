using Domain;
using Microsoft.EntityFrameworkCore;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DB
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly MyDBContext _context;
        public GenericRepository(MyDBContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            Table.Update(entity);
            return Task.FromResult(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                Table.Remove(entity);
            }
        }
    }
}
