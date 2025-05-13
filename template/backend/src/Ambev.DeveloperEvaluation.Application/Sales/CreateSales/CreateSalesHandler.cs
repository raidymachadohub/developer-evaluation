using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales;

public class CreateSalesHandler(ISalesRepository salesRepository,
                                IProductRepository productRepository,
                                 IMapper mapper) : IRequestHandler<CreateSalesCommand, CreateSalesResponse>
{
    public async Task<CreateSalesResponse> Handle(CreateSalesCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var newSales = mapper.Map<Domain.Entities.Sales>(request);
        
        var validateRulesAboutDiscount = await ValidateRulesAboutDiscount(newSales, cancellationToken);
        if (!validateRulesAboutDiscount.IsValid)
            throw new ValidationException(validateRulesAboutDiscount.Errors);
        
        var createdSales = await salesRepository.CreateAsync(newSales, cancellationToken);
        
        var result = mapper.Map<CreateSalesResponse>(createdSales);
        return result;
    }
    
    #region Methods Private

    /// <summary>
    /// 0% of discount for 4 or less items
    /// 10$ of discount if product is the same and has more than 4
    /// 20% of discount if product is the same and has more than 10 and less than 20
    /// If product is 20 or more, not possible
    /// </summary>
    /// <param name="sales"></param>
    /// /// <param name="cancellationToken"></param>
    private async Task<ValidationResult> ValidateRulesAboutDiscount(Domain.Entities.Sales sales, CancellationToken cancellationToken)
    {
        var hasLessThanFour = sales.SalesItems.Count < 4;

        if (hasLessThanFour)
        {
            return new ValidationResult
            {
                Errors = [new ValidationFailure("SalesItems", "Less than four items are not allowed")]
            };
        }
        
        var hasMoreThanTwelveSame = sales.SalesItems
            .GroupBy(x => x.ProductId)
            .Any(g => g.Count() > 20);

        if (hasMoreThanTwelveSame)
        {
            return new ValidationResult
            {
                Errors = [new ValidationFailure("SalesItems", "More than twelve same products are not allowed")]
            };
        }
        
        var hasProductWithMoreThanFourAndLessTen = sales.SalesItems
            .GroupBy(x => x.ProductId)
            .Any(g => g.Count() > 4 && g.Count() < 10);

        if (hasProductWithMoreThanFourAndLessTen)
        {
            decimal total = 0;
            foreach (var item in sales.SalesItems)
            {
                var price = await GetPriceProductAsync(item.ProductId, cancellationToken);
                total += price * item.Quantity;
            }
            sales.TotalSales = total * 0.9m;
        }
        
        var hasProductBetweenTenAndTwelveSame = sales.SalesItems
            .GroupBy(x => x.ProductId)
            .Any(g => g.Count() > 10 && g.Count() < 20 );

        if (!hasProductBetweenTenAndTwelveSame) return new ValidationResult();
        {
            decimal total = 0;

            foreach (var item in sales.SalesItems)
            {
                var price = await GetPriceProductAsync(item.ProductId, cancellationToken);
                total += price * item.Quantity;
            }

            sales.TotalSales = total * 0.8m; // aplica 20% de desconto
        }
        return new ValidationResult();
    }
    
    private async Task<decimal> GetPriceProductAsync(Guid productId, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(productId, cancellationToken);
        
        if (product == null)
            throw new Exception("Product not found");
        
        return product.GetNetValue();
    }
    
    #endregion Methods Private
}