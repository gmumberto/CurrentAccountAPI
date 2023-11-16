using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentAccountAPI.Domain.Entity.Validations
{
    internal class TransactionValidation : AbstractValidator<Transaction>
    {
        public TransactionValidation()
        {
            RuleFor(p => p.transactionDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("The {PropertyName} field must be less than or equal to the current date.");


            RuleFor(x => x.transactionAmount)
                   .Cascade(CascadeMode.Stop)
                   .LessThanOrEqualTo(999999999999999.99m).WithMessage("The {PropertyName} field must be less than or equal to {ComparisonValue}");

            RuleFor(x => x.transactionRemainingBalance)
                   .Cascade(CascadeMode.Stop)
                   .LessThanOrEqualTo(999999999999999.99m).WithMessage("The {PropertyName} field must be less than or equal to {ComparisonValue}");
        }        
    }
}
