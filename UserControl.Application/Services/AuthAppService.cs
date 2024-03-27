using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl.Application.Interfaces;
using UserControl.Domain.Interfaces.Services;

namespace UserControl.Application.Services
{
    public class AuthAppService : IAuthAppService { 

        private readonly IUserControlDomainService _userControlDomainService;

        public AuthAppService(IUserControlDomainService userControlDomainService)
        {
            _userControlDomainService = userControlDomainService;
        }

        public async Task LoginAsync(string email, string password)
        {
            var userAuth = _userControlDomainService.GetByEmailAsync(email);

        }

        public async Task ResetPassword(string email)
        {
            throw new NotImplementedException();
        }
    }
}
