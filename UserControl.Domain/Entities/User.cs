using FluentValidation.Results;
using UserControl.Domain.Validations;


namespace UserControl.Domain.Entities
{
    public class User : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public ValidationResult Validate
            => new UserValidation().Validate(this);
    }
}
