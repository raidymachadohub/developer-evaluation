using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch;

public class DeleteBranchHandler(IBranchRepository branchRepository) : IRequestHandler<DeleteBranchCommand, DeleteBranchResponse>
{
    public async Task<DeleteBranchResponse> Handle(DeleteBranchCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteBranchValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var success = await branchRepository.DeleteAsync(command.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Branch with ID {command.Id} not found");

        return new DeleteBranchResponse { Success = true };
    }
}