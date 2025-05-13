using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

public class CreateBranchCommand : IRequest<CreateBranchResponse>
{
    public string Name { get; set; } = string.Empty;
}