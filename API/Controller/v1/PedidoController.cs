using Application.Command;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
namespace API.Controller.v1;

[ApiVersion("1.0")]
public class PedidoController: BaseController
{
    private readonly PedidoServices _services;

    public PedidoController(PedidoServices services)
    {
        _services = services;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pedidos = await _services.Listar();
        return Ok(pedidos);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get()
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(PedidoInsertCommand command)
    {
        var result = await _services.Add(command);
        return Ok(result);
    }
    
}