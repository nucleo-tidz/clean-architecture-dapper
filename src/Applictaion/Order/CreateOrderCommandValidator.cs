using FluentValidation;

namespace Applictaion.Order
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(_ => _.Name).NotEmpty();
            RuleFor(_ => _.CreatedBy).NotEmpty();
            RuleFor(_ => _.ProductIds).NotEmpty();
        }
    }
}
