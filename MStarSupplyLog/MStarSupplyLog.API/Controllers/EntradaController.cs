using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStarSupplyLog.Application.DTOs;
using MStarSupplyLog.Application.Interfaces;

namespace MStarSupplyLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private readonly IEntradaService _entradaService;

        public EntradaController(IEntradaService entradaService)
        {
            _entradaService = entradaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntradaDTO>>> Get()
        {
            var entradas = await _entradaService.GetAllAsync();
            if (entradas == null)
            {
                return NotFound();
            }
            return Ok(entradas);
        }

        [HttpGet("{id}", Name = "GetEntrada")]
        public async Task<ActionResult<EntradaDTO>> Get(int? id)
        {
            var entrada = await _entradaService.GetByIdAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }
            return Ok(entrada);
        }

        [HttpGet("PorMes")]
        public async Task<ActionResult<IEnumerable<EntradaDTO>>> GetPorData([FromQuery] DateTime data)
        {
            // Verificar se a data informada é válida (exemplo simples)
            if (data == default(DateTime) || data < DateTime.MinValue || data > DateTime.MaxValue)
            {
                return BadRequest();
            }

            var entradasPorData = await _entradaService.GetByDateAsync(data);

            if (entradasPorData == null || !entradasPorData.Any())
            {
                return NotFound();
            }

            return Ok(entradasPorData);
        }

        [HttpPost]
        public async Task<ActionResult<EntradaDTO>> Post([FromBody] EntradaDTO entradaDTO)
        {
            if (entradaDTO == null)
            {
                return BadRequest();
            }
            await _entradaService.AddAsync(entradaDTO);
            return new CreatedAtRouteResult("GetEntrada", new { id = entradaDTO.Id }, entradaDTO);
        }

        [HttpPut]
        public async Task<ActionResult<EntradaDTO>> Put([FromBody] EntradaDTO entradaDTO)
        {
            if (entradaDTO == null)
            {
                return BadRequest();
            }
            await _entradaService.UpdateAsync(entradaDTO);
            return CreatedAtAction(nameof(Get), new { id = entradaDTO.Id }, entradaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EntradaDTO>> Delete(int? id)
        {
            var entrada = await _entradaService.GetByIdAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }
            await _entradaService.RemoveAsync(id);
            return Ok(entrada);
        }
    }
}

