using System.Text.Json.Serialization;

namespace UserControl.Application.DTO
{
    public class UserEditDTO : IEntityDTO<Guid>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
