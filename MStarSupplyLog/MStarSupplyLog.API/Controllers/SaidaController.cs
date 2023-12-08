using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStarSupplyLog.Application.DTOs;
using MStarSupplyLog.Application.Interfaces;
using MStarSupplyLog.Application.Services;

namespace MStarSupplyLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaidaController : ControllerBase
    {
        private readonly ISaidaService _saidaService;

        public SaidaController(ISaidaService saidaService)
        {
            _saidaService = saidaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaidaDTO>>> Get()
        {
            var saidas = await _saidaService.GetAllAsync();
            if (saidas == null)
            {
                return NotFound();
            }
            return Ok(saidas);
        }

        [HttpGet("{id}", Name = "GetSaida")]
        public async Task<ActionResult<SaidaDTO>> Get(int? id)
        {
            var saida = await _saidaService.GetByIdAsync(id);
            if (saida == null)
            {
                return NotFound();
            }
            return Ok(saida);
        }

        [HttpGet("PorMes")]
        public async Task<ActionResult<IEnumerable<SaidaDTO>>> GetPorData([FromQuery] DateTime data)
        {
            if (data == default(DateTime) || data < DateTime.MinValue || data > DateTime.MaxValue)
            {
                return BadRequest();
            }

            var saidaPorData = await _saidaService.GetByDateAsync(data);

            if (saidaPorData == null || !saidaPorData.Any())
            {
                return NotFound();
            }

            return Ok(saidaPorData);
        }

        [HttpPost]
        public async Task<ActionResult<SaidaDTO>> Post([FromBody] SaidaDTO saidaDTO)
        {
            if (saidaDTO == null)
            {
                return BadRequest();
            }
            await _saidaService.AddAsync(saidaDTO);
            return new CreatedAtRouteResult("GetSaida", new { id = saidaDTO.Id }, saidaDTO);
        }

        [HttpPut]
        public async Task<ActionResult<SaidaDTO>> Put([FromBody] SaidaDTO saidaDTO)
        {
            if (saidaDTO == null)
            {
                return BadRequest();
            }
            await _saidaService.UpdateAsync(saidaDTO);
            return CreatedAtAction(nameof(Get), new { id = saidaDTO.Id }, saidaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SaidaDTO>> Delete(int? id)
        {
            var saida = await _saidaService.GetByIdAsync(id);
            if (saida == null)
            {
                return NotFound();
            }
            await _saidaService.RemoveAsync(id);
            return Ok(saida);
        }
    }
}
