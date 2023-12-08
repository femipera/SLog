using AutoMapper;
using MStarSupplyLog.Application.DTOs;
using MStarSupplyLog.Application.Interfaces;
using MStarSupplyLog.Domain.Entities;
using MStarSupplyLog.Domain.Interfaces;

namespace MStarSupplyLog.Application.Services
{
    public class FabricanteService : IFabricanteService
    {
        private IFabricanteRepository _fabricanteRepository;
        private readonly IMapper _mapper;
        
        public FabricanteService(IFabricanteRepository fabricanteRepository, IMapper mapper)
        {
            _fabricanteRepository = fabricanteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FabricanteDTO>> GetAllAsync()
        {
            var fabricantes = await _fabricanteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FabricanteDTO>>(fabricantes);
        }

        public async Task<FabricanteDTO> GetByIdAsync(int? id)
        {
            var fabricante = await _fabricanteRepository.GetByIdAsync(id);
            return _mapper.Map<FabricanteDTO>(fabricante);
        }

        public async Task AddAsync(FabricanteDTO fabricanteDTO)
        {
            var fabricante = _mapper.Map<Fabricante>(fabricanteDTO);
            await _fabricanteRepository.CreateAsync(fabricante);
        }

        public async Task RemoveAsync(int? id)
        {
            var fabricante = _fabricanteRepository.GetByIdAsync(id).Result;
            await _fabricanteRepository.RemoveAsync(fabricante);
        }

        public async Task UpdateAsync(FabricanteDTO fabricanteDTO)
        {
            var fabricante = _mapper.Map<Fabricante>(fabricanteDTO);
            await _fabricanteRepository.UpdateAsync(fabricante);
        }
    }
}
