using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch;

public class DeleteBranchValidator : AbstractValidator<DeleteBranchCommand>
{
    public DeleteBranchValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Branch ID is required");
    }
}