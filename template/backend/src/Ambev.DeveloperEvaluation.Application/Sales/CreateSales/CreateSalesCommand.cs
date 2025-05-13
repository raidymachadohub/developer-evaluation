using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales;

public class CreateSalesCommand : IRequest<CreateSalesResponse>
{
    public long Number { get; set; }
    public string Client { get; set; }
    
    public Guid BranchId { get; set; }
    
    public ICollection<CreateSalesItemCommand> SalesItems { get; set; } = new List<CreateSalesItemCommand>();

    public bool Canceled { get; set; }
}