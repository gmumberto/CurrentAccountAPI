using FluentValidation;

namespace CurrentAccountAPI.Domain.Entity.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(p => p.customerName)
               .Cascade(CascadeMode.Stop)
               .MaximumLength(20).WithMessage("The {PropertyName} field can have {MaxLength} characters");

            RuleFor(p => p.customerSurename)
               .Cascade(CascadeMode.Stop)
               .MaximumLength(20).WithMessage("The {PropertyName} field can have {MaxLength} characters");

            RuleFor(x => x.customerAmountInAccount)
               .Cascade(CascadeMode.Stop)
               .LessThanOrEqualTo(999999999999999.99m).WithMessage("The {PropertyName} field must be less than or equal to {ComparisonValue}");

            RuleFor(x => x.customerCredit)
               .Cascade(CascadeMode.Stop)
               .LessThanOrEqualTo(999999999999999.99m).WithMessage("The {PropertyName} field must be less than or equal to {ComparisonValue}");
        }
    }
}
