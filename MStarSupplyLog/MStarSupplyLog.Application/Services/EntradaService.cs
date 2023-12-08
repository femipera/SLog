using AutoMapper;
using MStarSupplyLog.Application.DTOs;
using MStarSupplyLog.Application.Interfaces;
using MStarSupplyLog.Domain.Entities;
using MStarSupplyLog.Domain.Interfaces;

namespace MStarSupplyLog.Application.Services
{
public class EntradaService : IEntradaService
    {
        private IEntradaRepository _entradaRepository;
        private readonly IMapper _mapper;
        public EntradaService(IEntradaRepository entradaRepository, IMapper mapper)
        {
            _entradaRepository = entradaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EntradaDTO>> GetAllAsync()
        {
            var entradas = await _entradaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EntradaDTO>>(entradas);
        }

        public async Task<IEnumerable<EntradaDTO>> GetByDateAsync(DateTime data)
        {
            var entradas = await _entradaRepository.GetByDateAsync(data);
            return _mapper.Map<IEnumerable<EntradaDTO>>(entradas);
        }

        public async Task<EntradaDTO> GetByIdAsync(int? id)
        {
            var entrada = await _entradaRepository.GetByIdAsync(id);    
            return _mapper.Map<EntradaDTO>(entrada);
        }

        public async Task<EntradaDTO> GetSaidaMercadoriaAsync(int? id)
        {
            var entrada = await _entradaRepository.GetEntradaMercadoriaAsync(id);
            return _mapper.Map<EntradaDTO>(entrada);
        }

        public async Task AddAsync(EntradaDTO entradaDTO)
        {
            var entrada = _mapper.Map<Entrada>(entradaDTO);
            await _entradaRepository.CreateAsync(entrada);
        }

        public async Task RemoveAsync(int? id)
        {
            var entrada = _entradaRepository.GetByIdAsync(id).Result;
            await _entradaRepository.RemoveAsync(entrada);
        }

        public async Task UpdateAsync(EntradaDTO entradaDTO)
        {
            var entrada = _mapper.Map<Entrada>(entradaDTO);
            await _entradaRepository.UpdateAsync(entrada);
        }  
    }
}
