using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch;

public class DeleteBranchProfile : Profile
{
    public DeleteBranchProfile()
    {
        CreateMap<DeleteBranchCommand, Branch>();
        CreateMap<Branch, DeleteBranchResponse>();
    }
}