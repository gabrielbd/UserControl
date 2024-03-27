using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl.Application.DTO;

namespace UserControl.Application.Interfaces
{
    public interface IAuthAppService
    {
        Task LoginAsync(string email, string password);
        Task ResetPassword(string email);
    }
}
