using MassTransitContigencia.Models;

namespace MassTransitContigencia.ApplicationSerivce.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        void CadastrarUsuario(Usuario usuario);
        List<Usuario> GetAll();
    }
}
