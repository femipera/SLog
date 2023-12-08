using AutoMapper;
using MStarSupplyLog.Application.DTOs;
using MStarSupplyLog.Application.Interfaces;
using MStarSupplyLog.Domain.Entities;
using MStarSupplyLog.Domain.Interfaces;

namespace MStarSupplyLog.Application.Services
{
    public class TipoMercadoriaService : ITipoMercadoriaService
    {
        private ITipoMercadoriaRepository _tipoMercadoriaRepository;
        private readonly IMapper _mapper;

        public TipoMercadoriaService(ITipoMercadoriaRepository tipoMercadoriaRepository, IMapper mapper)
        {
            _tipoMercadoriaRepository = tipoMercadoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoMercadoriaDTO>> GetAllAsync()
        {
            var tipoMercadorias = await _tipoMercadoriaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TipoMercadoriaDTO>>(tipoMercadorias);
        }

        public async Task<TipoMercadoriaDTO> GetByIdAsync(int? id)
        {
            var tipoMercadoria = await _tipoMercadoriaRepository.GetByIdAsync(id);
            return _mapper.Map<TipoMercadoriaDTO>(tipoMercadoria);
        }

        public async Task AddAsync(TipoMercadoriaDTO tipoMercadoriaDTO)
        {
            var tipoMercadoria = _mapper.Map<TipoMercadoria>(tipoMercadoriaDTO);
            await _tipoMercadoriaRepository.CreateAsync(tipoMercadoria);
        }

        public async Task RemoveAsync(int? id)
        {
            var tipoMercadoria = _tipoMercadoriaRepository.GetByIdAsync(id).Result;
            await _tipoMercadoriaRepository.RemoveAsync(tipoMercadoria);
        }

        public async Task UpdateAsync(TipoMercadoriaDTO tipoMercadoriaDTO)
        {
            var tipoMercadoria = _mapper.Map<TipoMercadoria>(tipoMercadoriaDTO);
            await _tipoMercadoriaRepository.UpdateAsync(tipoMercadoria);
        }   

    }
}
