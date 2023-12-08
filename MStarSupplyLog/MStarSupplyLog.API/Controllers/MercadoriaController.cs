using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStarSupplyLog.Application.DTOs;
using MStarSupplyLog.Application.Interfaces;

namespace MStarSupplyLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoriaController : ControllerBase
    {
        private readonly IMercadoriaService _mercadoriaService;

        public MercadoriaController(IMercadoriaService mercadoriaService)
        {
            _mercadoriaService = mercadoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MercadoriaDTO>>> Get()
        {
            var mercadorias = await _mercadoriaService.GetAllAsync();
            if (mercadorias == null)
            {
                return NotFound();
            }
            return Ok(mercadorias);
        }

        [HttpGet("{id}", Name = "GetMercadoria")]
        public async Task<ActionResult<MercadoriaDTO>> Get(int? id)
        {
            var mercadorias = await _mercadoriaService.GetByIdAsync(id);
            if (mercadorias == null)
            {
                return NotFound();
            }
            return Ok(mercadorias);
        }

        [HttpPost]
        public async Task<ActionResult<MercadoriaDTO>> Post([FromBody] MercadoriaDTO mercadoriaDTO)
        {
            if (mercadoriaDTO == null)
            {
                return BadRequest();
            }
            await _mercadoriaService.AddAsync(mercadoriaDTO);
            return new CreatedAtRouteResult("GetMercadoria", new { id = mercadoriaDTO.Id }, mercadoriaDTO);
        }

        [HttpPut]
        public async Task<ActionResult<MercadoriaDTO>> Put([FromBody] MercadoriaDTO mercadoriaDTO)
        {
            if (mercadoriaDTO == null)
            {
                return BadRequest();
            }
            await _mercadoriaService.UpdateAsync(mercadoriaDTO);
            return CreatedAtAction(nameof(Get), new { id = mercadoriaDTO.Id }, mercadoriaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MercadoriaDTO>> Delete(int? id)
        {
            var mercadoria = await _mercadoriaService.GetByIdAsync(id);
            if (mercadoria == null)
            {
                return NotFound();
            }
            await _mercadoriaService.RemoveAsync(id);
            return Ok(mercadoria);
        }
    }
}