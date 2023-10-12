using System;
using System.Threading.Tasks;
using Domain.Entites;

namespace Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    ICinemaRepository PostRepository { get; }
    // ICommentRepository CommentRepository { get; }
    Task Save();
}
