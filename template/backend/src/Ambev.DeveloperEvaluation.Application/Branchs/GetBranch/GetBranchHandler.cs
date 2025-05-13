using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

public class GetBranchHandler(IBranchRepository branchRepository,
                              IMapper mapper) : IRequestHandler<GetBranchCommand, List<GetBranchResponse>>
{
    public async Task<List<GetBranchResponse>> Handle(GetBranchCommand request, CancellationToken cancellationToken)
    {
        var branchs = await branchRepository.GetAllAsync(cancellationToken);
        
        var result = mapper.Map<List<GetBranchResponse>>(branchs);
        
        return result;
    }
}