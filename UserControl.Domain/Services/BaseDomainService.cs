using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl.Domain.Entities;
using UserControl.Domain.Interfaces.Repositories;
using UserControl.Domain.Interfaces.Services;

namespace UserControl.Domain.Services
{
    public class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class 
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseDomainService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _repository.CreateAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return  _repository.GetAllAsync();
        }

        public Task<TEntity> GetByIdAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(user);
        }
    }
}
