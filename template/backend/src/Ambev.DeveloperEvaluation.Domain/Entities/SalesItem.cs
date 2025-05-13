using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// This class represents item of each sales transaction.
/// </summary>
public class SalesItem : BaseEntity
{
    public int Quantity { get; set; }
    
    public Guid SalesId { get; set; }

    [ForeignKey("SalesId")] 
    public Sales Sales { get; set; } = null!;
    
    public Guid ProductId { get; set; }
    
    [ForeignKey("ProductId")] 
    public Product Product { get; set; } = null!;
    
    public decimal Discount { get; set; }
}