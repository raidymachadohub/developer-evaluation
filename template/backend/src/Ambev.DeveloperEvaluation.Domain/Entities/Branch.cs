using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// This class represents branch
/// </summary>
public class Branch : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Sales>? Sales { get; set; }
}