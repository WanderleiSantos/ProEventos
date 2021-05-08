using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Application.DTOs;

namespace ProLotes.API.Controllers
{
    [ApiController]
    [Route("api/lotes")]
    public class LotesController : ControllerBase
    {
        private readonly ILoteService _lotesService;

        public LotesController(ILoteService lotesService)
        {
            _lotesService = lotesService;
        }

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                var lotes = await _lotesService.GetLotesByEventoIdAsync(eventoId);
                if (lotes == null) return NoContent();

                return Ok(lotes);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao recuperar lotes. Erro: {e.Message}");
            }
        }

        [HttpPut("{eventoId}")]
        public async Task<IActionResult> Put(int eventoId, LoteDto[] models)
        {
            try
            {
                var lotes = await _lotesService.SaveLote(eventoId, models);
                if (lotes == null) return NoContent();
                return Ok(lotes);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao recuperar lotes. Erro: {e.Message}");
            }
        }

        [HttpDelete("{eventoId}/{loteId}")]
        public async Task<IActionResult> Delete(int eventoId, int loteId)
        {
            try
            {
                var lote = await _lotesService.GetLoteByIdsAsync(eventoId, loteId);
                if (lote == null) return NoContent();

                return await _lotesService.DeleteLote(lote.EventoId, lote.Id) 
                    ? Ok(new { message = "Lote Deletado" }) 
                    : throw new Exception("Ocorreu um problema não específico ao tentar deletar Lote.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar lotes. Erro: {ex.Message}");
            }
        }
    }
}