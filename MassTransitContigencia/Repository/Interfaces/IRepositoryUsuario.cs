using MassTransitContigencia.Models;

namespace MassTransitContigencia.Repository.Interfaces
{
    public interface IRepositoryUsuario
    {
        List<Usuario> GetAll();
        void CadastrarUsuario(Usuario usuario);
    }
}
