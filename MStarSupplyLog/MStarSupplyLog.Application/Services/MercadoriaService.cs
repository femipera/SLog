using AutoMapper;
using MStarSupplyLog.Application.DTOs;
using MStarSupplyLog.Application.Interfaces;
using MStarSupplyLog.Domain.Entities;
using MStarSupplyLog.Domain.Interfaces;

namespace MStarSupplyLog.Application.Services
{
    public class MercadoriaService : IMercadoriaService
    {
        private IMercadoriaRepository _mercadoriaRepository;
        private readonly IMapper _mapper;
        public MercadoriaService(IMercadoriaRepository mercadoriaRepository, IMapper mapper)
        {
            _mercadoriaRepository = mercadoriaRepository;
            _mapper = mapper;         
        }

        public async Task<IEnumerable<MercadoriaDTO>> GetAllAsync()
        {
            var mercadorias = await _mercadoriaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MercadoriaDTO>>(mercadorias);
        }

        public async Task<MercadoriaDTO> GetByIdAsync(int? id)
        {
            var mercadoria = await _mercadoriaRepository.GetByIdAsync(id);
            return _mapper.Map<MercadoriaDTO>(mercadoria);
        }

        public async Task<MercadoriaDTO> GetMercadoriaFabricanteAsync(int? id)
        {
            var mercadoria = await _mercadoriaRepository.GetMercadoriaFabricanteAsync(id);
            return _mapper.Map<MercadoriaDTO>(mercadoria); 
        }

        public async Task<MercadoriaDTO> GetMercadoriaTipoMercadoriaAsync(int? id)
        {
            var mercadoria = await _mercadoriaRepository.GetMercadoriaTipoAsync(id);
            return _mapper.Map<MercadoriaDTO>(mercadoria);
        }

        public async Task AddAsync(MercadoriaDTO mercadoriaDTO)
        {
            var mercadoria = _mapper.Map<Mercadoria>(mercadoriaDTO);
            await _mercadoriaRepository.CreateAsync(mercadoria);
        }
        public async Task UpdateAsync(MercadoriaDTO mercadoriaDTO)
        {
            var mercadoria = _mapper.Map<Mercadoria>(mercadoriaDTO);
            await _mercadoriaRepository.UpdateAsync(mercadoria);
        }

        public async Task RemoveAsync(int? id)
        {
            var mercadoria = _mercadoriaRepository.GetByIdAsync(id).Result;
            await _mercadoriaRepository.RemoveAsync(mercadoria);
        }


    }
}
