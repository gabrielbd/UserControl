using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl.Domain.Entities;

namespace UserControl.Domain.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation() {
            RuleFor(u => u.Id)
                .NotEmpty()
                .WithMessage("Id é obrigatório");

            RuleFor(u => u.Name)
            .NotEmpty()
            .Length(3, 150)
            .WithMessage("Nome de usuário inválido");

            RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email inválido");

            RuleFor(u => u.Password)
           .NotEmpty()
           .Length(6, 20).WithMessage("Senha deve ter de 6 a 20 caracteres")
           .Matches(@"[A-Z]+").WithMessage("Senha precisa ter pelo menos 1 letra maiúscula")
           .Matches(@"[a-z]+").WithMessage("Senha precisa ter pelo menos 1 letra minúscula")
           .Matches(@"[0-9]+").WithMessage("Senha deve ter pelo menos 1 número")
           .Matches(@"[\!\?\*\.\@\(\)]+").WithMessage("Senha deve ter pelo menos 1 caractere especial (! ? * . @ )");
        }
    }
}
