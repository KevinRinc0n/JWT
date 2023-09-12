
using Dominio.Interfaces;
using Dominio.Entities;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class RolRepository : GenericRepository<Rol>, IRol
    {
        private readonly RetoContext _context;

        public RolRepository(RetoContext context) : base(context)
        {
            _context = context;
        }

    }
}