using Dominio.Interfaces;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class UserRepository : GenericRepository<User>, IUser
    {
        private readonly RetoContext _context;
        public UserRepository(RetoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _context.Users
                                    .Include(u => u.Rols)
                                    .Include(u => u.RefreshTokens)
                                    .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(u => u.Rols)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == username.ToLower());
        }
    }
}   