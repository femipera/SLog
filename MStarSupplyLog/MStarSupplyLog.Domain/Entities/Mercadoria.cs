using MStarSupplyLog.Domain.Validation;

namespace MStarSupplyLog.Domain.Entities
{
    public class Mercadoria : Entity
    {
        public string Nome { get; private set; }
        public int NumeroRegistro { get; private set; }
        public string Descricao { get; private set; }
        public int TipoMercadoriaId { get; private set; }
        public TipoMercadoria TipoMercadoria { get; private set; }
        public int FabricanteId { get; private set; }
        public Fabricante Fabricante { get; private set; }
        public ICollection<Entrada> Entradas { get; set; }
        public ICollection<Saida> Saidas { get; set; }

        public Mercadoria(string nome, int numeroRegistro, string descricao)
        {
            ValidateDomain(nome, numeroRegistro, descricao);                 
        }

        public void Update(string nome, int numeroRegistro, string descricao, int fabricanteId, int tipoMercadoriaId)
        {
            ValidateDomain(nome, numeroRegistro, descricao);
            FabricanteId = fabricanteId;
            TipoMercadoriaId = tipoMercadoriaId;
        }

        private void ValidateDomain(string nome, int numeroRegistro, string descricao)
        {
            DomainExceptionValidadion.When(string.IsNullOrEmpty(nome), "O Campo nome é obrigatório");

            DomainExceptionValidadion.When(nome.Length < 4, "O Campo nome deve conter no minimo 4 caracteres.");

            DomainExceptionValidadion.When(numeroRegistro < 0, "Valor inválido para Número do Registro.");

            DomainExceptionValidadion.When(string.IsNullOrEmpty(descricao), "O Campo descrição é obrigatório");

            DomainExceptionValidadion.When(nome.Length < 6, "O Campo descrição deve conter no minimo 6 caracteres.");

            Nome = nome;
            NumeroRegistro = numeroRegistro;
            Descricao = descricao;
        }
    }
}
