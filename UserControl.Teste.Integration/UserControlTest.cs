using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using UserControl.Application.DTO;
using Xunit;

namespace UserControl.Teste.Integration
{
    public class UserControlTest
    {
        [Fact]
        public async Task TestCreatedUser()
        {
            var faker = new Faker("pt_BR");

            var dto = new UserDTO
            {
                Name = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Password = $"@1{faker.Internet.Password(8)}"
            };

            var content = new StringContent(JsonConvert.SerializeObject(dto), 
                Encoding.UTF8, "application/json");

            var result = await new WebApplicationFactory<Program>()
                     .CreateClient().PostAsync("/api/UserControl", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }
    }
}