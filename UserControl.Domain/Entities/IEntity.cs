using FluentValidation.Results;

namespace UserControl.Domain.Entities
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
        public ValidationResult Validate { get; }
    }
}
