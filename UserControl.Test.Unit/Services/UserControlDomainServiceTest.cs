using Bogus;
using UserControl.Domain.Entities;
using UserControl.Domain.Interfaces.Services;
using Xunit;

namespace UserControl.Test.Unit.Services
{
    public class UserControlDomainServiceTest
    {

        private readonly IUserControlDomainService _userControlDomainService;

        public UserControlDomainServiceTest(IUserControlDomainService userControlDomainService)
        {
            _userControlDomainService = userControlDomainService;
        }

        [Fact]
        public void TestNewUser()
        {
            try
            {
                var usuario = NewUser();
                _userControlDomainService.CreateAsync(usuario);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        private User NewUser()
        {
            var faker = new Faker("pt_BR");
            var usuario = new User
            {
                Id = Guid.NewGuid(),
                Name = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Password = $"@{faker.Internet.Password(10)}",
            };
            return usuario;
        }
    }
}
