using Application.Contracts.Persistence;
using Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MOVIEAPPDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("MovieAppConnectionString")));


        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICinemaRepository, CinemaRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();

        return services;
    }
}

