using MassTransit;
using MassTransitContigencia.Models;
using MassTransitContigencia.Repository.Interfaces;

namespace MassTransitContigencia.Consumers
{
    public class ConsumerOperante : IConsumer<Usuario>
    {
        readonly IRepositoryUsuario _repositoryUsuario;

        public ConsumerOperante(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public Task Consume(ConsumeContext<Usuario> context)
        {
            var usuario = new Usuario()
            {
                Nome = context.Message.Nome,
                Email = context.Message.Email,
            };


            _repositoryUsuario.CadastrarUsuario(usuario);
            return Task.CompletedTask;
        }
    }
}
