using MassTransit;
using ServicoDePagamento.Interface;

namespace ServicoDePagamento;

public class ClienteEventConsumer : IConsumer<ClienteEvent>
{
    private readonly ILogger<ClienteEventConsumer> _logger;
    private readonly IClienteRepository _clienteRepository;

    public ClienteEventConsumer(ILogger<ClienteEventConsumer> logger, IClienteRepository clienteRepository)
    {
        _logger = logger;
        _clienteRepository = clienteRepository;
    }

    public async Task Consume(ConsumeContext<ClienteEvent> context)
    {
        var message = context.Message;
        _logger.LogInformation("cliente criado documento:{Documento}, nome:{Nome}",message.documento,message.nome);
        
        var cliente = await _clienteRepository.BuscarTodos();
        var clienteResponse = cliente.FirstOrDefault(x=>x.Documento == message.documento);
        clienteResponse.Documento = "12345678908";

        await Task.Delay(10000);

        await _clienteRepository.Atualizar(clienteResponse);
        await _clienteRepository.Commit();        
    }
}
