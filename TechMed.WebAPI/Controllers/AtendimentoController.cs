using Microsoft.AspNetCore.Mvc;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;

namespace TechMed.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoService _atendimentoService;

        public AtendimentoController(IAtendimentoService atendimentoService)
        {
            _atendimentoService = atendimentoService;
        }

        [HttpGet("atendimentos")]
        public IActionResult GetAll()
        {
            var atendimentos = _atendimentoService.GetAll();
            return Ok(atendimentos);
        }

        [HttpGet("atendimento/{id}")]
        public IActionResult GetById(int id)
        {
            var atendimento = _atendimentoService.GetById(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            return Ok(atendimento);
        }

        [HttpPost("atendimento")]
        public IActionResult Create([FromBody] NewAtendimentoInputModel novoAtendimento)
        {
            if (novoAtendimento == null)
            {
                return BadRequest();
            }

            var atendimentoId = _atendimentoService.Create(novoAtendimento);
            return CreatedAtAction(nameof(GetById), new { id = atendimentoId }, novoAtendimento);
        }

        [HttpPut("atendimento/{id}")]
        public IActionResult Update(int id, [FromBody] NewAtendimentoInputModel atendimentoAtualizado)
        {
            if (_atendimentoService.GetById(id) == null)
            {
                return NotFound();
            }

            _atendimentoService.Update(id, atendimentoAtualizado);
            return Ok(atendimentoAtualizado);
        }

        [HttpDelete("atendimento/{id}")]
        public IActionResult Delete(int id)
        {
            var existingAtendimento = _atendimentoService.GetById(id);
            if (existingAtendimento == null)
            {
                return NotFound();
            }

            _atendimentoService.Delete(id);
            return Ok();
        }
    }
}
