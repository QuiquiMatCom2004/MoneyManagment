using Domain;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DB
{
    public class UnitOfWork(MyDBContext context) : IUnitOfWork
    {
        private readonly MyDBContext _context = context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity
        {
            var type = typeof(TEntity);

            if(_repositories.ContainsKey(type))
                return (IRepository<TEntity>)_repositories[type];
            
            var implementationType = typeof(GenericRepository<>).MakeGenericType(typeof(TEntity));

            var instance = Activator.CreateInstance(implementationType, _context);

            if (instance == null)
            {
                throw new InvalidOperationException($"Could not create instance of {implementationType.FullName}");
            }

            _repositories[type] = instance;

            return (IRepository<TEntity>)instance;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
