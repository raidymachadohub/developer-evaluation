using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

public class CreateBranchHandler(IBranchRepository branchRepository,
                                 IMapper mapper) : IRequestHandler<CreateBranchCommand, CreateBranchResponse>
{
    public async Task<CreateBranchResponse> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateBranchValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var newBranch = mapper.Map<Branch>(command);
        var createdBranch = await branchRepository.CreateAsync(newBranch, cancellationToken);
        
        var result = mapper.Map<CreateBranchResponse>(createdBranch);
        return result;
    }
}