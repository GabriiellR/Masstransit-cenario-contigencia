using MassTransit;
using MassTransitContigencia.ApplicationSerivce.Interfaces;
using MassTransitContigencia.Models;
using MassTransitContigencia.Repository.Interfaces;

namespace MassTransitContigencia.ApplicationSerivce
{
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        readonly IRepositoryUsuario _repositoryUsuario;
        readonly IBus _bus;
        public ApplicationServiceUsuario(IRepositoryUsuario repositoryUsuario, IBus bus)
        {
            _repositoryUsuario = repositoryUsuario;
            _bus = bus;
        }

        public async void CadastrarUsuario(Usuario usuario)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:operacional"));

            await endpoint.Send<Usuario>(new Usuario
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
            });
        }

        public List<Usuario> GetAll()
        {
            return _repositoryUsuario.GetAll();
        }
    }
}
