using Microsoft.AspNetCore.Mvc;
using MStarSupplyLog.Application.DTOs;
using MStarSupplyLog.Application.Interfaces;

namespace MStarSupplyLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMercadoriaController : ControllerBase
    {
        private readonly ITipoMercadoriaService _tipoMercadoriaService;

        public TipoMercadoriaController(ITipoMercadoriaService tipoMercadoriaService)
        {
            _tipoMercadoriaService = tipoMercadoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMercadoriaDTO>>> Get()
        {
            var fabricantes = await _tipoMercadoriaService.GetAllAsync();
            if (fabricantes == null)
            {
                return NotFound();
            }
            return Ok(fabricantes);
        }

        [HttpGet("{id}", Name = "GetTipoMercadoria")]
        public async Task<ActionResult<TipoMercadoriaDTO>> Get(int? id)
        {
            var tipoMercadoria = await _tipoMercadoriaService.GetByIdAsync(id);
            if (tipoMercadoria == null)
            {
                return NotFound();
            }
            return Ok(tipoMercadoria);
        }

        [HttpPost]
        public async Task<ActionResult<TipoMercadoriaDTO>> Post([FromBody] TipoMercadoriaDTO tipoMercadoriaDTO)
        {
            if (tipoMercadoriaDTO == null)
            {
                return BadRequest();
            }
            await _tipoMercadoriaService.AddAsync(tipoMercadoriaDTO);
            return new CreatedAtRouteResult("GetTipoMercadoria", new { id = tipoMercadoriaDTO.Id }, tipoMercadoriaDTO);
        }

        [HttpPut]
        public async Task<ActionResult<TipoMercadoriaDTO>> Put([FromBody] TipoMercadoriaDTO tipoMercadoriaDTO)
        {
            if (tipoMercadoriaDTO == null)
            {
                return BadRequest();
            }
            await _tipoMercadoriaService.UpdateAsync(tipoMercadoriaDTO);
            return CreatedAtAction(nameof(Get), new { id = tipoMercadoriaDTO.Id }, tipoMercadoriaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoMercadoriaDTO>> Delete(int? id)
        {
            var tipoMercadoria = await _tipoMercadoriaService.GetByIdAsync(id);
            if (tipoMercadoria == null)
            {
                return NotFound();
            }
            await _tipoMercadoriaService.RemoveAsync(id);
            return Ok(tipoMercadoria);
        }
    }
}
