using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl.Domain.Entities;

namespace UserControl.Domain.Interfaces.Repositories
{
    public interface IUserControlRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string email);

    }
}
