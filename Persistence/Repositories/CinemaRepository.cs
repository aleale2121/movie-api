using Application.Contracts.Persistence;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
{
    private readonly MOVIEAPPDbContext _dbContext;

    public CinemaRepository(MOVIEAPPDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}

