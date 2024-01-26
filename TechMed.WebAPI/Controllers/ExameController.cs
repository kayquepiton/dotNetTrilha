using Microsoft.AspNetCore.Mvc;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Core.Exceptions;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class ExameController : ControllerBase
    {
        private readonly IExameService _exameService;

        public ExameController(IExameService exameService)
        {
            _exameService = exameService;
        }

        [HttpGet("exames")]
        public IActionResult GetExames()
        {
            var exames = _exameService.GetAllExames();
            return Ok(exames);
        }

        [HttpPost("exames")]
        public IActionResult CreateExame([FromBody] NewExameInputModel exameInputModel)
        {
            try
            {
                var exameId = _exameService.CreateExame(exameInputModel);
                return CreatedAtAction(nameof(GetExames), new { id = exameId }, exameInputModel);
            }
            catch (ExameNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ExameAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("exames/{id}")]
        public IActionResult GetExameById(int id)
        {
            try
            {
                var exame = _exameService.GetExameById(id);
                return Ok(exame);
            }
            catch (ExameNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
