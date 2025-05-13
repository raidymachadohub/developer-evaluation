using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.DeleteBranch;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class BranchProfile : Profile
{
    public BranchProfile()
    {
        CreateMap<CreateBranchRequest, CreateBranchCommand>();
        CreateMap<DeleteBranchRequest, DeleteBranchCommand>();
    }
}