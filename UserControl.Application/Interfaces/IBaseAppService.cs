using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl.Application.DTO;
using UserControl.Domain.Entities;

namespace UserControl.Application.Interfaces
{
    public interface IBaseAppService<TEntity, TEntityDTO> 
        where TEntity : class
        where TEntityDTO : IEntityDTO<Guid>
    {
        Task CreateAsync(TEntityDTO entity);
        Task UpdateAsync(TEntityDTO entity);
        Task DeleteAsync(TEntityDTO entity);
        Task DeleteAsync(Guid id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);

    }
}
