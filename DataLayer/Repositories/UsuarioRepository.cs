using DataLayer.Context;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(InstituicaoEnsinoABCDbContext context)
            : base(context) { }

        public IEnumerable<Usuario> GetAll()
        {
            return Query(x => x.Email != "");
        }
    }
}
