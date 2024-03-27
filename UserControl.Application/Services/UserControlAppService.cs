using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl.Application.DTO;
using UserControl.Application.Interfaces;
using UserControl.Domain.Entities;
using UserControl.Domain.Interfaces.Services;

namespace UserControl.Application.Services
{
    public class UserControlAppService : BaseAppService<User, UserDTO>, IUserControlAppService
    {
        private readonly IUserControlDomainService _userControlDomainService;
        private readonly IMapper _mapper;
        public UserControlAppService(IBaseDomainService<User> domainService, IMapper mapper, IUserControlDomainService userControlDomainService)
            : base(domainService, mapper)
        {
            _userControlDomainService = userControlDomainService;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetByEmailAsync(string email)
        {
            var user = await _userControlDomainService.GetByEmailAsync(email);
            return _mapper.Map<UserDTO>(user);

        }

        public async Task CreateUserValidationAsync(UserDTO user)
        {
            var userData = _mapper.Map<User>(user);
            var validation = userData.Validate;

            if (!validation.IsValid)
                throw new ValidationException(string.Join(Environment.NewLine, validation.Errors.Select(error => error.ErrorMessage)));

            await _userControlDomainService.CreateAsync(userData);
        }

        public async Task UpdateUserValidationAsync(UserEditDTO user)
        {
            var userData = _mapper.Map<User>(user);
            var validation = userData.Validate;

            if (!validation.IsValid)
                throw new ValidationException(string.Join(Environment.NewLine, validation.Errors.Select(error => error.ErrorMessage)));

            await _userControlDomainService.UpdateAsync(userData);
        }
    }
}
