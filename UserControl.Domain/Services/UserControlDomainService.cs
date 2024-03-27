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
    public class UserControlDomainService : BaseDomainService<User>, IUserControlDomainService
    {
        private readonly IUserControlRepository _repository;
        public UserControlDomainService(IUserControlRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _repository.GetByEmailAsync(email);
            
        }
    }
}
