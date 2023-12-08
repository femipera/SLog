using AutoMapper;
using MStarSupplyLog.Application.DTOs;
using MStarSupplyLog.Application.Interfaces;
using MStarSupplyLog.Domain.Entities;
using MStarSupplyLog.Domain.Interfaces;

namespace MStarSupplyLog.Application.Services
{
    public class SaidaService : ISaidaService
    {
        private ISaidaRepository _saidaRepository;
        private readonly IMapper _mapper;
        public SaidaService(ISaidaRepository saidaRepository, IMapper mapper)
        {
            _saidaRepository = saidaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SaidaDTO>> GetAllAsync()
        {
            var saidas = await _saidaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SaidaDTO>>(saidas);
        }

        public async Task<SaidaDTO> GetByIdAsync(int? id)
        {
            var saida = await _saidaRepository.GetByIdAsync(id);    
            return _mapper.Map<SaidaDTO>(saida);
        }

        public async Task<IEnumerable<SaidaDTO>> GetByDateAsync(DateTime data)
        {
            var saidas = await _saidaRepository.GetByDateAsync(data);
            return _mapper.Map<IEnumerable<SaidaDTO>>(saidas);
        }

        public async Task<SaidaDTO> GetSaidaMercadoriaAsync(int? id)
        {
            var saida = await _saidaRepository.GetSaidaMercadoriaAsync(id);
            return _mapper.Map<SaidaDTO>(saida);
        }

        public async Task AddAsync(SaidaDTO saidaDTO)
        {
            var saida = _mapper.Map<Saida>(saidaDTO);
            await _saidaRepository.CreateAsync(saida);
        }

        public async Task RemoveAsync(int? id)
        {
            var saida = _saidaRepository.GetByIdAsync(id).Result;
            await _saidaRepository.RemoveAsync(saida);
        }

        public async Task UpdateAsync(SaidaDTO saidaDTO)
        {
            var saida = _mapper.Map<Saida>(saidaDTO);
            await _saidaRepository.UpdateAsync(saida);
        }
    }
}
