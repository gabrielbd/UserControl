using Bogus;
using FluentAssertions;
using UserControl.Domain.Entities;
using UserControl.Domain.Interfaces.Repositories;
using Xunit;

namespace UserControl.Test.Unit.Repositories
{
    public class UserControlRepositoryTest
    {
        private readonly IUserControlRepository _userControlRepository;

        public UserControlRepositoryTest(IUserControlRepository userControlRepository)
        {
            _userControlRepository = userControlRepository;
        }

        [Fact]
        public async Task TestCreate()
        {
            var usuario = CreateUser();

            var usuarioById = await _userControlRepository.GetByIdAsync(usuario.Id);
            usuarioById.Should().NotBeNull();

        }


        [Fact]
        public async Task TestUpdate()
        {
            var faker = new Faker("pt_BR");

            var usuario = CreateUser();
            usuario.Name = faker.Person.FullName;
            usuario.Email = faker.Internet.Email();
            usuario.Password = $"1@{faker.Internet.Password(10)}";

            await _userControlRepository.UpdateAsync(usuario);

            var usuarioById = await _userControlRepository.GetByIdAsync(usuario.Id);
            usuarioById.Should().NotBeNull();


        }


        [Fact]
        public async Task TestDelete()
        {
            var usuario = CreateUser();

            await _userControlRepository.DeleteAsync(usuario);

            var usuarioById = await _userControlRepository.GetByIdAsync(usuario.Id);
            usuarioById.Should().BeNull();
        }


        [Fact]
        public async Task TestGetAllAsync()
        {
            var user = CreateUser();

            var usuarios = await _userControlRepository.GetAllAsync();

            usuarios.FirstOrDefault(u => u.Id.Equals(user.Id)).Should().NotBeNull();


        }


        [Fact]
        public async Task TestGetById()
        {
            var user = CreateUser();

            var userById = await _userControlRepository.GetByIdAsync(user.Id);
            userById.Should().NotBeNull();
        }


        [Fact]
        public async Task TestGetByEmail()
        {
            var user = CreateUser();

            var userByEmail = await _userControlRepository.GetByEmailAsync(user.Email);
            userByEmail.Should().NotBeNull();

        }

        private User CreateUser()
        {
            var faker = new Faker("pt_BR");
            var usuario = new User
            {
                Id = Guid.NewGuid(),
                Name = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Password = $"@1{faker.Internet.Password(10)}",
            };
            _userControlRepository.CreateAsync(usuario);
            return usuario;
        }

    }
}
