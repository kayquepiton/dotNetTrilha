using Microsoft.AspNetCore.Mvc;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

public class ExameController : ControllerBase
{
    private readonly IExameService _exameService;
    public List<ExameViewModel> Exames => _exameService.GetAll();
    public ExameController(IExameService service) => _exameService = service;

    [HttpGet("exames")]
    public IActionResult Get(){
        return Ok(Exames);
    }

    [HttpPost("exames")]
    public IActionResult Post([FromBody] ExameInputModel exame){
        _exameService.Create(exame);
        return Created(nameof(Post), exame);
    }
}
