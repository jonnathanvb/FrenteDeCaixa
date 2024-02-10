using Application.Command;
using Application.Command.DefaultValue;
using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace API.Controller.v1;


[ApiVersion("1.0")]
public class ProdutoController: BaseController
{
    private readonly ProdutoService _produtoService;

    public ProdutoController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _produtoService.Listar();
        return Ok(list);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ProdutoInsertCommand command)
    {
        var dto = await _produtoService.Add(command);
        return base.Created("" ,dto);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Alt(ProdutoUpdateCommand command, int id)
    {
        command.Id = id;
         await _produtoService.Alt(command);
        return Ok();
    }
}