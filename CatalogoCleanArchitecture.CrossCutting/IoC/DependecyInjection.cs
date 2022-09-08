using CatalogoCleanArchitecture.Application.Interfaces;
using CatalogoCleanArchitecture.Application.Mappings;
using CatalogoCleanArchitecture.Application.Services;
using CatalogoCleanArchitecture.Domain.Interfaces;
using CatalogoCleanArchitecture.Infrastructure.Context;
using CatalogoCleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCleanArchitecture.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            // options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            //), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ObterStringConexao"),
               builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();


            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
         
            return services;
        }
    }
}
