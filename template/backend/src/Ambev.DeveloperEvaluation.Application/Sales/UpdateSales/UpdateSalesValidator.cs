using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;

public class UpdateSalesValidator : AbstractValidator<UpdateSalesCommand>
{
    public UpdateSalesValidator()
    {
        RuleFor(sales => sales.Number)
            .NotNull().WithMessage("Number is required.")
            .GreaterThan(0).WithMessage("Number must be greater than 0");
        
        RuleFor(sales => sales.Client).NotEmpty().WithMessage("Client is required.");
        RuleFor(sales => sales.BranchId).NotEmpty().WithMessage("BranchId is required."); 
        RuleFor(sales => sales.SalesItems).NotEmpty().WithMessage("SalesItems is required."); 
        
        RuleFor(sales => sales.TotalSales)
            .NotNull().WithMessage("TotalSales is required.")
            .GreaterThan(0).WithMessage("TotalSales must be greater than 0");
    }
}
