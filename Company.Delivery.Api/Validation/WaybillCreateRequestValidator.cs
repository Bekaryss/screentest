using Company.Delivery.Api.Controllers.Waybills.Request;
using FluentValidation;

namespace Company.Delivery.Api.Validation
{
    /// <summary>
    /// Validator for WaybillCreateRequestValidator.
    /// </summary>
    public class WaybillCreateRequestValidator : AbstractValidator<WaybillCreateRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WaybillCreateRequestValidator"/> class.
        /// </summary>
        public WaybillCreateRequestValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Waybill number is required.")
                .MaximumLength(50).WithMessage("Waybill number cannot exceed 50 characters.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date cannot be in the future.");

            RuleForEach(x => x.Items).SetValidator(new CargoItemCreateRequestValidator());
        }
    }
}
