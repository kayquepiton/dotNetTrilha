using Microsoft.AspNetCore.Mvc; 
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedcioController : ControllerBase
{
    private readonly IMedicoService _medicoService;
    public List<MedicoViewModel> Pacientes => _medicoService.GetAll();
    public MedcioController(IMedicoService service) => _medicoService = service;

    [HttpGet("medicos")]
    public IActionResult Get(){
        return Ok(Pacientes);
    }

    [HttpGet("medico/{id}")]
    public IActionResult Get(int id){
        var medicos = _medicoService?.GetById(id);
        return Ok(medicos);
    }

    [HttpPost("medico")]
    public IActionResult Post([FromBody] MedicoInputModel medico){
        _medicoService?.Create(medico);
        return Created(nameof(Post), medico);
    }

    [HttpPost("medicos/{id}/atendimento")]
    public IActionResult Post(int id, [FromBody] AtendimentoInputModel atendimento){
        _medicoService?.CreateAtendimento(id, atendimento);
        return Created(nameof(Post), atendimento);
    }

    [HttpPut("medico/{id}")]
    public IActionResult Put(int id, [FromBody] MedicoInputModel medico){
        if(_medicoService?.GetById(id) is null)
            return NotFound();
        _medicoService?.Update(id, medico);
        return Ok(_medicoService?.GetById(id));
    }

    [HttpDelete("medico/{id}")]
    public IActionResult Delete(int id){
        if(_medicoService?.GetById(id) is null)
            return NotFound();
        _medicoService?.Delete(id);
        return Ok();
    }
}
