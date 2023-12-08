using System.ComponentModel.DataAnnotations;

namespace MStarSupplyLog.Application.DTOs
{
    public class TipoMercadoriaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MinLength(4, ErrorMessage = "O campo Nome deve ter no mínimo 4 caracteres.")]
        [MaxLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
    }
}
