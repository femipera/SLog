using Microsoft.AspNetCore.Mvc;
using MStarSupplyLog.Application.DTOs;
using MStarSupplyLog.Application.Interfaces;

namespace MStarSupplyLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricantesController : ControllerBase
    {
        private readonly IFabricanteService _fabricanteService;

        public FabricantesController(IFabricanteService fabricanteService)
        {
            _fabricanteService = fabricanteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FabricanteDTO>>> Get()
        {
            var fabricantes = await _fabricanteService.GetAllAsync();
            if(fabricantes == null)
            {
                return NotFound();
            }
            return Ok(fabricantes);      
        }

        [HttpGet("{id}", Name = "GetFabricante")]
        public async Task<ActionResult<FabricanteDTO>> Get(int? id)
        {
            var fabricante = await _fabricanteService.GetByIdAsync(id);
            if(fabricante == null)
            {
                return NotFound();
            }
            return Ok(fabricante);
        }

        [HttpPost]
        public async Task<ActionResult<FabricanteDTO>> Post([FromBody] FabricanteDTO fabricanteDTO)
        {
            if(fabricanteDTO == null)
            {
                return BadRequest();
            }
            await _fabricanteService.AddAsync(fabricanteDTO);
            return new CreatedAtRouteResult("GetFabricante", new { id = fabricanteDTO.Id }, fabricanteDTO);
        }

        [HttpPut]
        public async Task<ActionResult<FabricanteDTO>> Put([FromBody] FabricanteDTO fabricanteDTO)
        {
            if(fabricanteDTO == null)
            {
                return BadRequest();
            }
            await _fabricanteService.UpdateAsync(fabricanteDTO);
            return CreatedAtAction(nameof(Get), new { id = fabricanteDTO.Id }, fabricanteDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FabricanteDTO>> Delete(int? id)
        {
            var fabricante = await _fabricanteService.GetByIdAsync(id);
            if(fabricante == null)
            {
                return NotFound();
            }
            await _fabricanteService.RemoveAsync(id);
            return Ok(fabricante);
        }
    }
}
