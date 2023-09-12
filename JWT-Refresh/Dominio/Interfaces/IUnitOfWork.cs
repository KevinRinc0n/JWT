namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IUser Users { get; }
    IRol Rols { get; }
    Task<int> SaveAsync();
}