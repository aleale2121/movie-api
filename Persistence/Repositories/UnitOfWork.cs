using AutoMapper;
using Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{

    private readonly MOVIEAPPDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private ICinemaRepository _cinemaRepository;
    private IMovieRepository _movieRepository;


    public UnitOfWork(MOVIEAPPDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        this._httpContextAccessor = httpContextAccessor;
    }

    public ICinemaRepository CinemaRepository => 
        _cinemaRepository ??= new CinemaRepository(_context);

    public IMovieRepository MovieRepository => 
        _movieRepository ??= new MovieRepository(_context);
    
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save() 
    {
        // var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

        // await _context.SaveChangesAsync(username);
    }
}

