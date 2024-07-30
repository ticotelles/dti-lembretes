using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeLembretes.Models;

namespace SistemaDeNotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly ContextoDB _contextoDB;

        public NotaController(ContextoDB contextoDB)
        {
            _contextoDB = contextoDB;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lembrete>>> GetNotas()
        {
            try
            {
                var notas = await _contextoDB.Lembretes.ToListAsync();
                return Ok(notas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Lembrete>> AddNota(Lembrete objNota)
        {
            try
            {
                _contextoDB.Lembretes.Add(objNota);
                await _contextoDB.SaveChangesAsync();
                return CreatedAtAction(nameof(GetNotas), new { id = objNota.Id }, objNota);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteNota(int id)
        {
            try
            {
                var nota = await _contextoDB.Lembretes.FindAsync(id);
                if (nota == null)
                {
                    return NotFound();
                }

                _contextoDB.Lembretes.Remove(nota);
                await _contextoDB.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
