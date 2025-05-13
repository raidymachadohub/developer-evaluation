using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class BranchRepository(DefaultContext context) : BaseRepository<Branch>(context), IBranchRepository;