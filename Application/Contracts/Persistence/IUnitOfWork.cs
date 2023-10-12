using System;
using System.Threading.Tasks;
using Domain.Entites;

namespace Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    ICinemaRepository CinemaRepository { get; }
    IMovieRepository MovieRepository { get; }
    Task Save();
}
