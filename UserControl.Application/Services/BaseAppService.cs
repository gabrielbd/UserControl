using AutoMapper;
using UserControl.Application.DTO;
using UserControl.Application.Interfaces;
using UserControl.Domain.Interfaces.Services;

namespace UserControl.Application.Services
{
    public class BaseAppService<TEntity , TEntityDTO> : IBaseAppService<TEntity , TEntityDTO>
        where TEntity : class
        where TEntityDTO : IEntityDTO<Guid>
    {

        private readonly IBaseDomainService<TEntity> _domainService;
        private readonly IMapper _mapper;

        public BaseAppService(IBaseDomainService<TEntity> domainService, IMapper mapper)
        {
            _domainService = domainService;
            _mapper = mapper;
        }

        public async Task CreateAsync(TEntityDTO entity)
        {
            await _domainService.CreateAsync(_mapper.Map<TEntity>(entity));
            
        }

        public async Task UpdateAsync(TEntityDTO entity)
        {
            await _domainService.UpdateAsync(_mapper.Map<TEntity>(entity));
        }

        public async Task DeleteAsync(TEntityDTO entity)
        {
            await _domainService.DeleteAsync(_mapper.Map<TEntity>(entity));
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var entity = await _domainService.GetAllAsync();
            return entity.ToList();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity = await _domainService.GetByIdAsync(id);
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _domainService.DeleteAsync(id);
        }
    }
}
