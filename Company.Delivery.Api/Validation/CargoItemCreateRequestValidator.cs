using Company.Delivery.Api.Controllers.Waybills.Request;
using FluentValidation;

namespace Company.Delivery.Api.Validation
{
    /// <summary>
    /// Validator for CargoItemCreateRequest.
    /// </summary>
    public class CargoItemCreateRequestValidator : AbstractValidator<CargoItemCreateRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CargoItemCreateRequestValidator"/> class.
        /// </summary>
        public CargoItemCreateRequestValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Cargo item number is required.")
                .MaximumLength(50).WithMessage("Cargo item number cannot exceed 50 characters.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Cargo item name is required.")
                .MaximumLength(100).WithMessage("Cargo item name cannot exceed 100 characters.");
        }
    }
}
