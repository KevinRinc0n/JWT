using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
    public class Unitofwork : IUnitOfWork, IDisposable
    {
        private readonly RetoContext context;
        private UserRepository _Users;
        private RolRepository _Rols;


    public Unitofwork(RetoContext _context)
        {
            context = _context;
        }

        public IUser Users
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new UserRepository(context);
                }
                return _Users;
            }
        }

    public IRol Rols
    {
        get
        {
            if (_Rols == null)
            {
                _Rols = new RolRepository(context);
            }
            return _Rols;
        }
    }
    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
    public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }