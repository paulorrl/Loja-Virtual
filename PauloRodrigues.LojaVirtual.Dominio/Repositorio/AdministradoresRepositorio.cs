using System.Linq;
using PauloRodrigues.LojaVirtual.Dominio.Entidades;

namespace PauloRodrigues.LojaVirtual.Dominio.Repositorio
{
    public class AdministradoresRepositorio
    {
        private readonly EntityFrameDbContext _context = new EntityFrameDbContext();

        public Administrador ObterAdministrador(Administrador admin)
        {
            return _context.Administradores.FirstOrDefault(a => a.Login == admin.Login /*&& a.Senha == admin.Senha*/);
        }
    }
}