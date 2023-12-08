using AutoMapper;
using MStarSupplyLog.Application.DTOs;
using MStarSupplyLog.Domain.Entities;

namespace MStarSupplyLog.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<TipoMercadoria, TipoMercadoriaDTO>().ReverseMap();
            CreateMap<Fabricante, FabricanteDTO>().ReverseMap();
            CreateMap<Mercadoria, MercadoriaDTO>().ReverseMap();
            CreateMap<Saida, SaidaDTO>().ReverseMap();
            CreateMap<Entrada, EntradaDTO>().ReverseMap();
        }
    }
}
