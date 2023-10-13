using Application.Contracts.Persistence;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    private readonly MOVIEAPPDbContext _dbContext;

    public MovieRepository(MOVIEAPPDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}

