﻿using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        
        builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ISalesItemRepository, SalesItemRepository>();
        builder.Services.AddScoped<ISalesRepository, SalesRepository>();
        builder.Services.AddScoped<IBranchRepository, BranchRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
    }
}