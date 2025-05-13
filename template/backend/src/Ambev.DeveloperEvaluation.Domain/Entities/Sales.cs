using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// This class represents a sales transaction
/// </summary>
public class Sales : BaseEntity
{
    public long Number { get; set; }
    
    public DateTime SalesAt { get; set; }

    public string Client { get; set; } = string.Empty;
    
    public Guid BranchId { get; set; }
    
    [ForeignKey("BranchId")]
    public Branch Branch { get; set; } = null!;
    
    public ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();
    
    public decimal TotalSales { get; set; }

    public bool Canceled { get; set; }
}