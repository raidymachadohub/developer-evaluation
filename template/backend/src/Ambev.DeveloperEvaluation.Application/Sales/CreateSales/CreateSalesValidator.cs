using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales;

public class CreateSalesValidator : AbstractValidator<CreateSalesCommand>
{
    public CreateSalesValidator()
    {
        RuleFor(sales => sales.Number)
            .NotNull().WithMessage("Number is required.")
            .GreaterThan(0).WithMessage("Number must be greater than 0");
        
        RuleFor(sales => sales.Client).NotEmpty().WithMessage("Client is required.");
        RuleFor(sales => sales.BranchId).NotEmpty().WithMessage("BranchId is required."); 
        RuleFor(sales => sales.SalesItems).NotEmpty().WithMessage("SalesItems is required."); 
    }
}
