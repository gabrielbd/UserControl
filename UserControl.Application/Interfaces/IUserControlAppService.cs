using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl.Application.DTO;
using UserControl.Domain.Entities;

namespace UserControl.Application.Interfaces
{
    public interface IUserControlAppService : IBaseAppService<User , UserDTO>
    {
        Task CreateUserValidationAsync(UserDTO entity);
        Task UpdateUserValidationAsync(UserEditDTO entity);
        Task<UserDTO> GetByEmailAsync(string email);
    }
}
