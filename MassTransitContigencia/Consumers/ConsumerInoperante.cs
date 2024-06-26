using MassTransit;
using MassTransitContigencia.Models;

namespace MassTransitContigencia.Consumers
{
    public class ConsumerInoperante : IConsumer<Usuario>
    {
        readonly IBus _bus;

        public ConsumerInoperante(IBus bus)
        {
            _bus = bus;
        }

        public async Task Consume(ConsumeContext<Usuario> context)
        {
            try
            {
                throw new Exception("Repositorio inoperante");
            }
            catch (Exception ex)
            {
            }
        }
    }
}

