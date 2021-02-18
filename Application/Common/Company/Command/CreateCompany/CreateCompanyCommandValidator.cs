using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Company.Queries.GetCustomers;

namespace Application.Common.Company.Command.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(v => v.OrganizationNo)
                .NotEmpty().WithMessage("Organization number is requred")
                .Must(x => x.Length > 0 && x.Length < 10).WithMessage("Organization number must have a value between 1 and 9 chars");
        }
    }
}
