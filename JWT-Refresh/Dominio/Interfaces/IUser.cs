using Dominio.Entities;
namespace Dominio.Interfaces;

public interface IUser : IGenericRepositor<User>
{
    Task<User> GetByUserNameAsync (string userName);
    Task<User> GetByRefreshTokenAsync(string username);
}