using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;

public class UpdateSalesCommand : IRequest<UpdateSalesResponse>
{
    public Guid Id { get; set; }
    
    public long Number { get; set; }
    
    public DateTime SalesAt { get; set; }

    public string Client { get; set; } = string.Empty;
    
    public Guid BranchId { get; set; }
    
    public ICollection<UpdateSalesItemCommand> SalesItems { get; set; } = new List<UpdateSalesItemCommand>();
    
    public decimal TotalSales { get; set; }

    public bool Canceled { get; set; }
}