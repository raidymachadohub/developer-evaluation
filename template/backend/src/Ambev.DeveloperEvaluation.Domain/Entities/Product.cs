using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// This class represents products
/// </summary>
public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Discount { get; set; }

    public ICollection<SalesItem> SalesItems { get; set; }
    
    public decimal GetNetValue() => Price - Discount;
}