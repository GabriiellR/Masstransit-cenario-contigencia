using MassTransitContigencia.Models;
using MassTransitContigencia.Repository.Interfaces;

namespace MassTransitContigencia.Repository
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        private readonly List<Usuario> _centroCusto = new List<Usuario>();

        public RepositoryUsuario()
        {
            _centroCusto.Add(new Usuario { Nome = "Gabriel Dias", Email = "gabriellrodriigues17@gmail.com" });
            _centroCusto.Add(new Usuario { Nome = "Rafael Faria", Email = "rafael.faria@gmail.com" });
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            _centroCusto.Add(usuario);
        }

        public List<Usuario> GetAll()
        {
            return _centroCusto;
        }
    }
}
