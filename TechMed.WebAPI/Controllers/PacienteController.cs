using Microsoft.AspNetCore.Mvc; 
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PacienteController : ControllerBase
{
    private readonly IPacienteService _pacienteService;
    public List<PacienteViewModel> Pacientes => _pacienteService.GetAll();
    public PacienteController(IPacienteService service) => _pacienteService = service;

    [HttpGet("pacientes")]
    public IActionResult Get(){
        return Ok(Pacientes);
    }

    [HttpGet("pacientes/{id}")]
    public IActionResult Get(int id){
        var pacientes = _pacienteService?.GetById(id);
        return Ok(pacientes);
    }

    [HttpPost("pacientes")]
    public IActionResult Post([FromBody] PacienteInputModel paciente){
        _pacienteService?.Create(paciente);
        return Created(nameof(Post), paciente);
    }

    [HttpPut("pacientes/{id}")]
    public IActionResult Put(int id, [FromBody] PacienteInputModel paciente){
        if(_pacienteService?.GetById(id) is null)
            return NotFound();
        _pacienteService?.Update(id, paciente);
        return Ok(_pacienteService?.GetById(id));
    }

    [HttpDelete("pacientes/{id}")]
    public IActionResult Delete(int id){
        if(_pacienteService?.GetById(id) is null)
            return NotFound();
        _pacienteService?.Delete(id);
        return Ok();
    }
}
