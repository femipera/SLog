using MStarSupplyLog.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MStarSupplyLog.Application.DTOs
{
    public class EntradaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo Quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo Data é obrigatório.")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O campo Local é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo Local deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O campo Local deve ter no máximo 100 caracteres.")]
        public string Local { get; set; }

        [Required(ErrorMessage = "O campo Mercadoria é obrigatório.")]
        public int MercadoriaId { get; set; }

        [JsonIgnore]
        public Mercadoria? Mercadoria { get; set; }
    }
}
