using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl.Domain.Entities;

namespace UserControl.Domain.Interfaces.Services
{
    public interface IUserControlDomainService : IBaseDomainService<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
