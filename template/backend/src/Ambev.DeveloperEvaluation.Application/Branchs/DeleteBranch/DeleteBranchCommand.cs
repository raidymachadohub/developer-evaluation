using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch;

public class DeleteBranchCommand : IRequest<DeleteBranchResponse>
{
    public Guid Id { get; } 
    
    public DeleteBranchCommand(Guid id)
    {
        Id = id;
    }
}