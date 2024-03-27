using FluentAssertions;
using UserControl.Domain.Entities;
using Xunit;

namespace UserControl.Test.Unit.Entities
{
    public class UserTest
    {
        [Fact]
        public void ValidarIdTest()
        {
            var user = new User
            {
                Id = Guid.Empty
            };

            user.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Id é obrigatório"))
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void ValidarNomeTest()
        {
            var user = new User
            {
                Name = string.Empty
            };

            user.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Nome de usuário inválido"))
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void ValidarEmailTest()
        {
            var user = new User
            {
                Email = string.Empty
            };

            user.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Endereço de email inválido"))
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void ValidarSenhaTest()
        {
            var user = new User();

            user.Password = string.Empty;

            user.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Senha deve ter de 8 a 20 caracteres"))
                .Should()
                .NotBeNull();

            user.Password = "adminadmin";

            user.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Senha deve ter pelo menos 1 letra maiúscula"))
                .Should()
                .NotBeNull();

            user.Password = "ADMINADMIN";

            user.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Senha deve ter pelo menos 1 letra minúscula"))
                .Should()
                .NotBeNull();

            user.Password = "adminADMIN";

            user.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Senha deve ter pelo menos 1 número"))
                .Should()
                .NotBeNull();

            user.Password = "Admin1234";

            user.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Senha deve ter pelo menos 1 caractere especial"))
                .Should()
                .NotBeNull();
        }
    }
}
