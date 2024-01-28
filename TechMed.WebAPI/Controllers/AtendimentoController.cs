using Microsoft.AspNetCore.Mvc;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

public class AtendimentoController : ControllerBase
{
    private readonly IAtendimentoService _atendimentoService;
    public List<AtendimentoViewModel> Atendimentos => _atendimentoService.GetAll();
    public AtendimentoController(IAtendimentoService service) => _atendimentoService = service;

    [HttpGet("atendimentos")]
    public IActionResult Get(){
        return Ok(Atendimentos);
    }

    [HttpPost("atendimento")]
    public IActionResult Post([FromBody] AtendimentoInputModel atendimento){
        _atendimentoService.Create(atendimento);
        return Created(nameof(Post), atendimento);
    }
}
