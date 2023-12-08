using MStarSupplyLog.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MStarSupplyLog.Application.DTOs
{
    public class MercadoriaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MinLength(4, ErrorMessage = "O campo Nome deve ter no mínimo 4 caracteres.")]
        [MaxLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O número do registro deve ser maior ou igual a 1.")]
        public int NumeroRegistro { get; set; }

        [MinLength(4, ErrorMessage = "O campo Descrição deve ter no mínimo 6 caracteres.")]
        [MaxLength(100, ErrorMessage = "O campo Descrição deve ter no máximo 500 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo obrigatório.")]
        public int FabricanteId { get; set; }
        [Required(ErrorMessage = "O campo obrigatório.")]
        public int TipoMercadoriaId { get; set; }

        [JsonIgnore]
        public Fabricante? Fabricante { get; set; }

        [JsonIgnore]
        public TipoMercadoria? TipoMercadoria { get; set; }
    }
}
