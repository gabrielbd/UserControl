using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl.Domain.Entities;
using UserControl.Domain.Interfaces.Repositories;
using UserControl.Infra.Contexts;

namespace UserControl.Infra.Repositories
{
    public class UserControlRepository : BaseRepository<User> , IUserControlRepository
    {
        private readonly SqlContexts _contexts;
        public UserControlRepository(SqlContexts context) 
            : base(context)
        {
            _contexts = context;
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return _contexts.User.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
